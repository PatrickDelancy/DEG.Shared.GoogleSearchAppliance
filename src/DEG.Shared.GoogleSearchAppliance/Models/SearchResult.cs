using System;
using System.Xml.Serialization;

namespace DEG.Shared.GoogleSearchAppliance.Models
{
    [Serializable]
    public class SearchResult
    {
        [XmlElement("U")]
        public string Url { get; set; }
        [XmlElement("T")]
        public string Title { get; set; }
        [XmlElement("S")]
        public string Abstract { get; set; }

        [XmlAttribute("N")]
        public long ResultIndex { get; set; }
    }
}