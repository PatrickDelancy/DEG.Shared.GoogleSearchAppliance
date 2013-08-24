using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Shared.GoogleSearchAppliance.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Category("Integration")]
        [Test]
        [Ignore]
        public void CanGetResultsFromAppliance()
        {
            var applianceUrl = "http://<yourappliancename>/search";
            var site = "default_collection";
            var client = "default_frontend";
            var page = 0;
            var pageSize = 15;

            var urlBuilder = new UrlBuilder();
            var searcher = new GoogleMini();
            var config = new GsaConfiguration(applianceUrl, site, client);

            var url = urlBuilder.Build(config, "test", 0, 15);
            using (var webClient = new WebClient())
            {
                var xml = webClient.DownloadString(url);
            }

            var result = searcher.Search(config, "test", 0, pageSize);

            result.Results.Should().NotBeNull();
            result.Results.Items.Should().NotBeEmpty();
        }
    }
}
