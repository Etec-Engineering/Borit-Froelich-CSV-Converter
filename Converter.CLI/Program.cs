using System;
using System.IO;
using System.Xml.Serialization;
using CommandLine;
using Converter.Document;

namespace Converter
{
    public class CommandLineOptions
    {
        [Option('s', "source", Required = true, HelpText = "Path to the source XML files directory.")]
        public string SourcePath { get; set; }
        
        [Option('d', "destination", Required = true, HelpText = "Path to the destination directory.")]
        public string DestinationPath { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed<CommandLineOptions>(options =>
            {
                Console.WriteLine($"Loading files from {options.SourcePath}");
                Console.WriteLine($"Writing files to {options.DestinationPath}");

                if (!Directory.Exists(options.SourcePath))
                {
                    throw new DirectoryNotFoundException();
                }
                
                if (!Directory.Exists(options.DestinationPath))
                {
                    throw new DirectoryNotFoundException();
                }
                
                var files = Directory.GetFiles(options.SourcePath);
                
                var serializer = new XmlSerializer(typeof(LeakTest));

                var csvDirectory = Path.Join(options.DestinationPath, "csv");
                var xmlDirectory = Path.Join(options.DestinationPath, "xml");

                Directory.CreateDirectory(csvDirectory);
                Directory.CreateDirectory(xmlDirectory);

                foreach (var file in files)
                {
                    using var fileStream =
                        File.OpenRead(file);
                    var document = (LeakTest)serializer.Deserialize(fileStream);
                
                    if (document == null)
                    {
                        return;
                    }
                    
                    var path = Path.Join(csvDirectory, $"{document.Header.PanelName}.csv");
                    if (!File.Exists(path))
                    {
                        File.WriteAllLines(path, new []{"panel,panelname,date,time,datetime,partno,parttype,testno,palettenno,operation,station,operator,tp,evalall,channelno,stu,tpno,eval,mea,value,limit_u,limit_u2,limit_l,unit"});
                    }
                
                    using StreamWriter writer =
                        new(path, append: true);

                    foreach (LeakTestChannelMeasurement leakTestChannelMeasurement in document.Channel.Measurements)
                    {
                        writer.WriteLine(
                            $"{document.Header.Panel},{document.Header.PanelName},{document.Header.Date},{document.Header.Time},{document.Header.DateTime.ToString("yyyy-MM-dd HH:mm:ss")},{document.Header.PartNumber},{document.Header.PartType},{document.Header.TestNumber},{document.Header.PaletteNumber},{document.Header.Operation},{document.Header.Station},{document.Header.Operator},{document.Header.Tp},{document.Header.EvalAll},{document.Channel.ChannelNumber},{document.Channel.Stu},{document.Channel.TpNumber},{document.Channel.Eval},{leakTestChannelMeasurement.Measurement},{leakTestChannelMeasurement.Value},{leakTestChannelMeasurement.LimitUpper},{leakTestChannelMeasurement.LimitUpper2},{leakTestChannelMeasurement.LimitLower},{leakTestChannelMeasurement.Unit}");                        
                    }

                    var baseFileName = Path.GetFileName(file);
                    File.Move(file, Path.Join(xmlDirectory, baseFileName));
                }
            });
        }
    }
}