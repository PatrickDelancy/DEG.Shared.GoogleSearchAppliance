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

            var config = new GsaConfiguration(applianceUrl, site, client);
            var searcher = new GoogleMini(config);
            
            var result = searcher.Search("test", page, pageSize);

            result.Results.Should().NotBeNull();
            result.Results.Items.Should().NotBeEmpty();
        }
    }
}
