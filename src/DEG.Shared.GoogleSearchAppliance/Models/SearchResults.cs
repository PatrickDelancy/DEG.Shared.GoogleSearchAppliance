using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DEG.Shared.GoogleSearchAppliance.Models
{
    [Serializable]
    public class SearchResults
    {
        [XmlElement("M")]
        public long EstimatedNumberOfResults { get; set; }

        [XmlAttribute("SN")]
        public long FirstResultIndex { get; set; }

        [XmlAttribute("EN")]
        public long LastResultIndex { get; set; }

        [XmlElement("R")]
        public List<SearchResult> Items { get; set; }
    }
}
