using Microsoft.EntityFrameworkCore;

namespace TimelineService.core;

public class TimelineDataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TimelineDB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Setup DB

        //Auto generate id
        modelBuilder.Entity<Timeline>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        #endregion
    }

    public DbSet<Timeline> Timelines { get; set; }
}