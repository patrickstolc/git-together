using Domain;

namespace SuggestionService.Core.Services
{
    public interface IService
    {

        public List<Suggestion> GetSuggestions();

        public Task<Suggestion> CreateSuggestion(Suggestion suggestion);


    }
}
