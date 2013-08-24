using System.IO;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace DEG.Shared.GoogleSearchAppliance.Tests
{
    [TestFixture]
    public class DeserializationTests
    {
        private readonly IGoogleSearchAppliance _search;

        public DeserializationTests()
        {
            _search = new GoogleMini();
        }

        [Test]
        public void CanGetResults()
        {
            var config = new GsaConfiguration("file://" + new FileInfo("./Data/output.xml").FullName, "", "");

            var results = _search.Search(config, "test");

            results.Should().NotBeNull();
            results.Results.Items.Should().NotBeEmpty();
        }

        [Test]
        public void CanGetResultsWithSuggestions()
        {
            var config = new GsaConfiguration("file://" + new FileInfo("./Data/output2.xml").FullName, "", "");

            var results = _search.Search(config, "test");

            results.Suggestions.Should().NotBeEmpty();
        }
    }
}
