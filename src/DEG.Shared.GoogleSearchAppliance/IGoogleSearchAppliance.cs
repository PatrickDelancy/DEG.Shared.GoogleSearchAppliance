using DEG.Shared.GoogleSearchAppliance.Models;

namespace DEG.Shared.GoogleSearchAppliance
{
    public interface IGoogleSearchAppliance
    {
        GoogleSearchResponse Search(string query);
        GoogleSearchResponse Search(string query, long start, long pageSize);
    }
}