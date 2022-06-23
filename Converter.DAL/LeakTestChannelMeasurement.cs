using System.Xml.Serialization;

namespace Converter.DAL;

public class LeakTestChannelMeasurement
{
    [XmlElement("MEA")]
    public string Measurement { get; set; }
        
    [XmlElement("VALUE")]
    public float Value { get; set; }
        
    [XmlElement("LIMIT_U")]
    public float LimitUpper { get; set; }
        
    [XmlElement("LIMIT_U2")]
    public float LimitUpper2 { get; set; }
        
    [XmlElement("LIMIT_L")]
    public float LimitLower { get; set; }
        
    [XmlElement("UNIT")]
    public string Unit { get; set; }
}