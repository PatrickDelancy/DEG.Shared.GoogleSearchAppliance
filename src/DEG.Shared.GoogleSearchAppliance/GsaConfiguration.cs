namespace DEG.Shared.GoogleSearchAppliance
{
    public interface IGsaConfiguration
    {
        string Uri { get; }
        string Site { get; }
        string Client { get; }
    }

    public class GsaConfiguration : IGsaConfiguration
    {
        public string Uri { get; private set; }
        public string Site { get; private set; }
        public string Client { get; private set; }

        public GsaConfiguration(string applianceUrl, string collectionOrSiteName, string clientOrLayoutName)
        {
            Uri = applianceUrl;
            Site = collectionOrSiteName;
            Client = clientOrLayoutName;
        }
    }
}
