using System.Globalization;
using System.Xml.Serialization;

namespace Converter.DAL;

public class LeakTestHeader
{
    [XmlElement("PANEL")]
    public string? Panel { get; set; }
        
    [XmlElement("PANELNAME")]
    public string? PanelName { get; set; }
        
    [XmlElement("DAT")]
    public string? Date { get; set; }
        
    [XmlElement("TIM")]
    public string? Time { get; set; }
        
    public DateTime DateTime => DateTime.ParseExact($"{Date} {Time}", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

    [XmlElement("PARTNO")]
    public string? PartNumber { get; set; }
        
    [XmlElement("PARTTYPE")]
    public string? PartType { get; set; }
        
    [XmlElement("TESTNO")]
    public int TestNumber { get; set; }
        
    [XmlElement("PALETTENNO")]
    public int PaletteNumber { get; set; }
        
    [XmlElement("OPERATION")]
    public int Operation { get; set; }
        
    [XmlElement("STATION")]
    public int Station { get; set; }
        
    [XmlElement("OPERATOR")]
    public int Operator { get; set; }
        
    [XmlElement("TP")]
    public string? Tp { get; set; }
        
    [XmlElement("EVALALL")]
    public string? EvalAll { get; set; }
}