using DevRanker.Model;

namespace DevRanker.Services
{
    public interface IRankingService
    {
        public Task<List<RankProfile>> GetProfiles(Profile profile);
    }
}
