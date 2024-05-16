

using Domain;

namespace SuggestionService.Core.Repository
{
    public interface IRepository
    {

        public Suggestion CreateSuggestion(Suggestion suggestion);

        public List<Suggestion> GetSuggestions();

    }
}
