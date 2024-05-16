using Suggestion.Core.Entities;

namespace Suggestion.Core.Repository
{
    public interface IRepository
    {

        public Entiies.Suggestion CreateSuggestion(Entiies.Suggestion);

        public List<Entiies.Suggestion> GetSuggestions();


    }
}
