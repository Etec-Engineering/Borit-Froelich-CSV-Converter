using System.Xml.Serialization;

namespace Converter.DAL;

public class LeakTestChannel
{
    [XmlElement("CHANNELNO")]
    public string? ChannelNumber { get; set; }
        
    [XmlElement("STU")]
    public int Stu { get; set; }
        
    [XmlElement("TPNO")]
    public int TpNumber { get; set; }
        
    [XmlElement("EVAL")]
    public string? Eval { get; set; }
        
    [XmlElement("MEAS")]
    public LeakTestChannelMeasurement[]? Measurements { get; set; }
}