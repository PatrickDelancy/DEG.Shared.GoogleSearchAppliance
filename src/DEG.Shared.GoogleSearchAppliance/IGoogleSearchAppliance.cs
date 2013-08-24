using DEG.Shared.GoogleSearchAppliance.Models;

namespace DEG.Shared.GoogleSearchAppliance
{
    public interface IGoogleSearchAppliance
    {
        GoogleSearchResponse Search(GsaConfiguration config, string query);
        GoogleSearchResponse Search(GsaConfiguration config, string query, long start, long pageSize);
    }
}