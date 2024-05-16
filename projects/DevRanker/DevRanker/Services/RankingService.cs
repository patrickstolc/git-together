using DevRanker.Model;

namespace DevRanker.Services
{
    public class RankingService : IRankingService
    {
        private IHTTPService _httpService;

        public RankingService(IHTTPService httpService)
        {
            _httpService = httpService;
        }
        public async  Task<List<RankProfile>> GetProfiles(Profile profile)
        {
            List<Profile> profiles = await _httpService.getProfiles(profile);
            List<RankProfile> rankedProfiles = RankProfiles(profiles);
            rankedProfiles.Sort((x , y) => y.Rank.CompareTo(x.Rank));

            return rankedProfiles;
 

        }
        private List<RankProfile> RankProfiles(List<Profile> profile)
        {
            List<RankProfile> rankedProfiles = new List<RankProfile>();
            if (profile == null || !profile.Any())
                throw new ArgumentException("The list of objects cannot be null or empty.");

            double minRank = profile.Min(o => o.LikeCount);
            double maxRank = profile.Max(o => o.LikeCount);

            double range = maxRank - minRank;

            foreach (var obj in profile)
            {
                var RProfile = new RankProfile();
                RProfile.Profile = obj;

                // If all ranks are the same, avoid division by zero
                if (range == 0)
                {
                    RProfile.Rank = 5.00; // All objects get the middle value
                }
                else
                {
                    RProfile.Rank = 10.0 * (obj.LikeCount - minRank) / range;
                }
                rankedProfiles.Add(RProfile);
            }
            return rankedProfiles;
        }
    }
}
