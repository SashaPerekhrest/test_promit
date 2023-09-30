using Microsoft.EntityFrameworkCore;
using TestPromIT.Application.interfaces;
using TestPromIT.Domain;
using TestPromIT.Persistence.EntityTypeConfigurations;

namespace TestPromIT.Persistence
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardDeck> Decks { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new DeckConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
