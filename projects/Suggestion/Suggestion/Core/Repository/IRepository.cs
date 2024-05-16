using Suggestion.Core.Entities;

namespace Suggestion.Core.Repository
{
    public interface IRepository
    {
        public List<RankProfile> GetRankProfiles();

        public Entiies.Suggestion CreateSuggestion();

        public List<Entiies.Suggestion> GetSuggestions();


    }
}
