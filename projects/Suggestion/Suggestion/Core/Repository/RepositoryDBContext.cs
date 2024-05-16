using Microsoft.EntityFrameworkCore;
using Suggestion.Core.Entiies;

namespace Suggestion.Core.Repository
{
    public class RepositoryDBContext: DbContext
    {

        public RepositoryDBContext(DbContextOptions<RepositoryDBContext> options, ServiceLifetime service) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entiies.Suggestion>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Entiies.Suggestion>().HasKey(s => s.Id);
        }

        public DbSet<Entiies.Suggestion> suggestions { get; set; }
    }
}
