using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DEG.Shared.GoogleSearchAppliance.Models
{
    [Serializable]
    [KnownType(typeof(Suggestion))]
    [KnownType(typeof(SearchResults))]
    [KnownType(typeof(SearchResult))]
    [XmlRoot("GSP")]
    public class GoogleSearchResponse
    {
        [XmlElement("RES")]
        public SearchResults Results { get; set; }

        [XmlElement("CT")]
        public string SearchComments { get; set; }

        [XmlElement("Q")]
        public string Query { get; set; }

        [XmlArray("Suggestions")]
        [XmlArrayItem("Suggestion")]
        public Suggestion[] Suggestions { get; set; }

        [XmlAttribute("VER")]
        public string Version { get; set; }

        [XmlElement("TM")]
        public double SecondsToExecute { get; set; }

        [XmlIgnore]
        public long PageSize { get; set; }
        [XmlIgnore]
        public long Page { get; set; }
        [XmlIgnore]
        public long TotalPages { get; set; }
    }

    [Serializable]
    public class Suggestion
    {
        [XmlAttribute("Q")]
        public string SuggestedSpelling { get; set; }
    }
}
