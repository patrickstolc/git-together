using Domain;
using Microsoft.EntityFrameworkCore;

namespace SuggestionService.Core.Repository
{
    public class Repository: IRepository
    {

        private DbContextOptions<RepositoryDBContext> _options;

        public Repository(RepositoryDBContext dbContext)
        {
            _options = new DbContextOptionsBuilder<RepositoryDBContext>().UseInMemoryDatabase("SuggestionDB").Options;
        }

        public Suggestion CreateSuggestion(Suggestion suggestion)
        {
            using(var context = new RepositoryDBContext(_options,ServiceLifetime.Scoped))
            {
                context.suggestions.Add(suggestion);
                context.SaveChanges();
                return suggestion;
            }
        }

        public List<Suggestion> GetSuggestions()
        {
            using(var context = new RepositoryDBContext(_options, ServiceLifetime.Scoped))
            {
                return context.suggestions.ToList();
            }
        }
    }
}
