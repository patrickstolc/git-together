using Domain;
using Microsoft.EntityFrameworkCore;

namespace SuggestionService.Core.Repository
{
    public class RepositoryDBContext: DbContext
    {

        public RepositoryDBContext(DbContextOptions<RepositoryDBContext> options, ServiceLifetime service) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suggestion>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Suggestion>().HasKey(s => s.Id);
        }

        public DbSet<Suggestion> suggestions { get; set; }
    }
}
