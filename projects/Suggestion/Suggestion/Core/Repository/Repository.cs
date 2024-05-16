using Microsoft.EntityFrameworkCore;
using Suggestion.Core.Entities;

namespace Suggestion.Core.Repository
{
    public class Repository: IRepository
    {

        private DbContextOptions<RepositoryDBContext> _options;

        public Repository(RepositoryDBContext dbContext)
        {
            _options = new DbContextOptionsBuilder<RepositoryDBContext>().UseInMemoryDatabase("SuggestionDB").Options;
        }

        public Entiies.Suggestion CreateSuggestion(Entiies.Suggestion suggestion)
        {
            using(var context = new RepositoryDBContext(_options,ServiceLifetime.Scoped))
            {
                context.suggestions.Add(suggestion);
                context.SaveChanges();
                return suggestion;
            }
        }

        public List<Entiies.Suggestion> GetSuggestions()
        {
            using(var context = new RepositoryDBContext(_options, ServiceLifetime.Scoped))
            {
                return context.suggestions.ToList();
            }
        }
    }
}
