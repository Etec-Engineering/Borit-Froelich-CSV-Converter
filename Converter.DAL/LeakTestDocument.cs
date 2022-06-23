using System.Xml.Serialization;

namespace Converter.DAL;

[XmlRoot("LEAKTEST")]
public class LeakTestDocument
{
    [XmlElement("HEADER")]
    public LeakTestHeader? Header { get; set; }
        
    [XmlElement("ERRORS")]
    public LeakTestErrors? Errors { get; set; }
        
    [XmlElement("CHANNEL")]
    public LeakTestChannel? Channel { get; set; }
}