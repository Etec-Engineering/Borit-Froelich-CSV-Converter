using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Converter.Document
{
    [XmlRoot("LEAKTEST")]
    public class LeakTest
    {
        [XmlElement("HEADER")]
        public LeakTestHeader Header { get; set; }
        
        [XmlElement("ERRORS")]
        public LeakTestErrors Errors { get; set; }
        
        [XmlElement("CHANNEL")]
        public LeakTestChannel Channel { get; set; }
    }
    
    public class LeakTestHeader
    {
        [XmlElement("PANEL")]
        public string Panel { get; set; }
        
        [XmlElement("PANELNAME")]
        public string PanelName { get; set; }
        
        [XmlElement("DAT")]
        public string Date { get; set; }
        
        [XmlElement("TIM")]
        public string Time { get; set; }
        
        public DateTime DateTime => DateTime.ParseExact($"{Date} {Time}", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        [XmlElement("PARTNO")]
        public string PartNumber { get; set; }
        
        [XmlElement("PARTTYPE")]
        public string PartType { get; set; }
        
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
        public string Tp { get; set; }
        
        [XmlElement("EVALALL")]
        public string EvalAll { get; set; }
    }

    public class LeakTestErrors
    {
        
    }

    public class LeakTestChannel
    {
        [XmlElement("CHANNELNO")]
        public string ChannelNumber { get; set; }
        
        [XmlElement("STU")]
        public int Stu { get; set; }
        
        [XmlElement("TPNO")]
        public int TpNumber { get; set; }
        
        [XmlElement("EVAL")]
        public string Eval { get; set; }
        
        [XmlElement("MEAS")]
        public LeakTestChannelMeasurement[] Measurements { get; set; }
    }

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
}