using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Persistence
{
    public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.Property(x => x.IndustryId).IsRequired();
            builder.Property(x => x.IndustryName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Enable).HasDefaultValue(true);
        }
    }
}
