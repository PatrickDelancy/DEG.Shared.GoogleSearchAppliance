using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Shared.GoogleSearchAppliance.Tests
{
    [TestFixture]
    public class DeserializationTests
    {
        [Test]
        public void CanGetResults()
        {
            var config = new GsaConfiguration("file://" + new FileInfo("./Data/output.xml").FullName, "", "");
            var googleMini = new GoogleMini(config);

            var results = googleMini.Search("test");

            results.Should().NotBeNull();
            results.Results.Items.Should().NotBeEmpty();
        }

        [Test]
        public void CanGetResultsWithSuggestions()
        {
            var config = new GsaConfiguration("file://" + new FileInfo("./Data/output2.xml").FullName, "", "");
            var googleMini = new GoogleMini(config);

            var results = googleMini.Search("test");

            results.Suggestions.Should().NotBeEmpty();
        }
    }
}
