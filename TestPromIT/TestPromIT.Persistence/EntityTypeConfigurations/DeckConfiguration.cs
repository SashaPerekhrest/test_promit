using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPromIT.Domain;

namespace TestPromIT.Persistence.EntityTypeConfigurations
{
    public class DeckConfiguration : IEntityTypeConfiguration<CardDeck>
    {
        public void Configure(EntityTypeBuilder<CardDeck> builder)
        {
            builder.HasKey(deck => deck.Id);
            builder.HasIndex(deck => deck.Id).IsUnique();
            builder.Property(deck => deck.Name).HasMaxLength(250);
        }
    }
}
