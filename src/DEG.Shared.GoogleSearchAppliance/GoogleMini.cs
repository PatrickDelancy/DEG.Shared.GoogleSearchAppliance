using System.Xml;
using System.Xml.Serialization;
using DEG.Shared.GoogleSearchAppliance.Models;

namespace DEG.Shared.GoogleSearchAppliance
{
    public class GoogleMini : IGoogleSearchAppliance
    {
        private readonly IUrlBuilder _urlBuilder = new UrlBuilder();

        public GoogleSearchResponse Search(GsaConfiguration config, string query)
        {
            var url = _urlBuilder.Build(config, query);
            return GetResults(url);
        }

        public GoogleSearchResponse Search(GsaConfiguration config, string query, long start, long pageSize)
        {
            var url = _urlBuilder.Build(config, query, start, pageSize);
            return GetResults(url);
        }

        private static GoogleSearchResponse GetResults(string url)
        {
            var serializer = new XmlSerializer(typeof (GoogleSearchResponse));
            var xmlReader = new XmlTextReader(url);
            var result = (GoogleSearchResponse) serializer.Deserialize(xmlReader);
            return result;
        }
    }
}
