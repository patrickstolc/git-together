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

        public Entiies.Suggestion CreateSuggestion()
        {
            throw new NotImplementedException();
        }

        public List<RankProfile> GetRankProfiles()
        {
            throw new NotImplementedException();
        }

        public List<Entiies.Suggestion> GetSuggestions()
        {
            throw new NotImplementedException();
        }
    }
}
