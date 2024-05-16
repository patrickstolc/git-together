using Suggestion.Core.Entiies;

namespace Suggestion.Core.Services
{
    public interface IService
    {

        public List<Entiies.Suggestion> GetSuggestions();

        public Task<Entiies.Suggestion> CreateSuggestion(Entiies.Suggestion);


    }
}
