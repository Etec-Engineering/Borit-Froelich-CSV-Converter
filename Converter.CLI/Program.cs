using System;
using System.IO;
using System.Xml.Serialization;
using CommandLine;
using Converter.CORE;

namespace Converter
{
    public class CommandLineOptions
    {
        [Option('s', "source", Required = true, HelpText = "Path to the source XML files directory.")]
        public string SourcePath { get; set; }
        
        [Option('d', "destination", Required = true, HelpText = "Path to the destination directory.")]
        public string DestinationPath { get; set; }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed<CommandLineOptions>(options =>
            {
                Console.WriteLine($"Input directory: {options.SourcePath}");
                Console.WriteLine($"Output directory: {options.DestinationPath}");

                XmlConverter.ConvertDirectory(options.SourcePath, options.DestinationPath);
            });
        }
    }
}