using DevRanker.Model;

namespace DevRanker.Services
{
    public interface IHTTPService
    {
        public Task<List<Profile>> getProfiles(Profile profile);

    }
}
