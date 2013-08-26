using System;
using System.Linq;
using System.Web;

namespace DEG.Shared.GoogleSearchAppliance
{
    public interface IUrlBuilder
    {
        string Build(IGsaConfiguration config, string query);
        string Build(IGsaConfiguration config, string query, long start, long pageSize);
    }

    public class UrlBuilder : IUrlBuilder
    {
        public string Build(IGsaConfiguration config, string query)
        {
            return Build(config, query, 0, 0);
        }

        public string Build(IGsaConfiguration config, string query, long start, long pageSize)
        {
            var url = config.Uri +
                      "?site=" + HttpUtility.UrlEncode(config.Site) +
                      "&client=" + HttpUtility.UrlEncode(config.Client) +
                      "&output=xml_no_dtd" +
                      "&q=" + HttpUtility.UrlEncode(query);

            if (pageSize > 0)
                url += "&num=" + pageSize;
            if (start > 0)
                url += "&start=" + start;

            return CleanUrl(url);
        }
        
        private static string CleanUrl(string url)
        {
            if (ProtocolSupportsQueryString(url) || !UrlHasQueryString(url)) return url;

            return RemoveQueryString(url);
        }

        private static string RemoveQueryString(string url)
        {
            return url.Split(new[] {'?'}, 2).FirstOrDefault();
        }

        private static bool UrlHasQueryString(string url)
        {
            return url.Contains("?");
        }

        private static bool ProtocolSupportsQueryString(string url)
        {
            return string.IsNullOrEmpty(url) || !url.StartsWith("file://");
        }
    }
}
