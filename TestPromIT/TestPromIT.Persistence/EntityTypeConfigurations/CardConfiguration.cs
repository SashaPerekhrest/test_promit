using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPromIT.Domain;

namespace TestPromIT.Persistence.EntityTypeConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(card => card.Id);
            builder.HasIndex(card => card.Id).IsUnique();
        }
    }
}
