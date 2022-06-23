using System.Collections;
using System.Xml.Serialization;
using Converter.DAL;

namespace Converter.CORE;

public static class XmlConverter
{
    public static void ConvertDirectory(string sourcePath, string destinationPath)
    {
        if (!Directory.Exists(sourcePath))
        {
            throw new DirectoryNotFoundException();
        }
                
        if (!Directory.Exists(destinationPath))
        {
            throw new DirectoryNotFoundException();
        }
                
        var files = Directory.GetFiles(sourcePath);
        var csvDirectory = Path.Join(destinationPath, "csv");
        var xmlDirectory = Path.Join(destinationPath, "xml");
        Directory.CreateDirectory(csvDirectory);
        Directory.CreateDirectory(xmlDirectory);

        foreach (var file in files)
        {
            try {
                Console.WriteLine($"Processing file: {file}");
                
                using var fileStream =
                    File.OpenRead(file);

                var document = ParseXml(fileStream);
                    
                if (document.Header == null || document.Channel?.Measurements == null)
                {
                    throw new Exception("Invalid LeakTest XML document");
                }
                    
                var path = Path.Join(csvDirectory, $"{document.Header.PanelName}.csv");

                var fileExists = File.Exists(path);
                    
                using StreamWriter writer =
                    new(path, append: true);
                    
                if (!fileExists)
                {
                    writer.WriteLine(GetCsvHeader());
                }

                foreach (var line in ConvertLeakTestToCsv(document))
                {
                    writer.WriteLine(line);
                }

                var baseFileName = Path.GetFileName(file);

                fileStream.Dispose();
                File.Move(file, Path.Join(xmlDirectory, baseFileName));
            } catch (Exception e) {
                Console.WriteLine($"Could not process file: {file}");
                Console.WriteLine(e);
            }
        }
    }
    
    private static string GetCsvHeader()
    {
        return
            "panel,panelname,date,time,datetime,partno,parttype,testno,palettenno,operation,station,operator,tp,evalall,channelno,stu,tpno,eval,mea,value,limit_u,limit_u2,limit_l,unit";
    }

    private static LeakTestDocument ParseXml(FileStream fileStream)
    {
        var xmlSerializer = new XmlSerializer(typeof(LeakTestDocument));
            
        var document = (LeakTestDocument?)xmlSerializer.Deserialize(fileStream);

        if (document == null)
        {
            throw new Exception("Could not deserialize XML document");
        }

        return document;
    }

    private static ArrayList ConvertLeakTestToCsv(LeakTestDocument document)
    {
        if (document.Header == null || document.Channel?.Measurements == null)
        {
            throw new Exception("Invalid LeakTest XML document");
        }
        
        var output = new ArrayList();
        
        foreach (var leakTestChannelMeasurement in document.Channel.Measurements)
        {
            output.Add(
                $"{document.Header.Panel},{document.Header.PanelName},{document.Header.Date},{document.Header.Time},{document.Header.DateTime:yyyy-MM-dd HH:mm:ss},{document.Header.PartNumber},{document.Header.PartType},{document.Header.TestNumber},{document.Header.PaletteNumber},{document.Header.Operation},{document.Header.Station},{document.Header.Operator},{document.Header.Tp},{document.Header.EvalAll},{document.Channel.ChannelNumber},{document.Channel.Stu},{document.Channel.TpNumber},{document.Channel.Eval},{leakTestChannelMeasurement.Measurement},{leakTestChannelMeasurement.Value},{leakTestChannelMeasurement.LimitUpper},{leakTestChannelMeasurement.LimitUpper2},{leakTestChannelMeasurement.LimitLower},{leakTestChannelMeasurement.Unit}");
        }
        
        return output;
    }
}