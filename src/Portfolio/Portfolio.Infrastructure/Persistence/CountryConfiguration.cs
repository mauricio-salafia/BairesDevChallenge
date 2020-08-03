using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Persistence
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CountryName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Enable).HasDefaultValue(true);
        }
    }
}
