namespace DEG.Shared.GoogleSearchAppliance
{
    public class GsaConfiguration
    {
        public readonly string Uri;
        public readonly string Site;
        public readonly string Client;

        public GsaConfiguration(string applianceUri, string siteOrCollectionName, string clientOrFrontendName)
        {
            Uri = applianceUri;
            Site = siteOrCollectionName;
            Client = clientOrFrontendName;
        }
    }
}
