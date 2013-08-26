using System.Xml;
using System.Xml.Serialization;
using DEG.Shared.GoogleSearchAppliance.Models;

namespace DEG.Shared.GoogleSearchAppliance
{
    public class GoogleMini : IGoogleSearchAppliance
    {
        private readonly IGsaConfiguration _config;
        private readonly IUrlBuilder _urlBuilder = new UrlBuilder();

        public GoogleMini(IGsaConfiguration config)
        {
            _config = config;
        }

        public GoogleSearchResponse Search(string query)
        {
            var url = _urlBuilder.Build(_config, query);
            return GetResults(url);
        }

        public GoogleSearchResponse Search(string query, long start, long pageSize)
        {
            var url = _urlBuilder.Build(_config, query, start, pageSize);
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
