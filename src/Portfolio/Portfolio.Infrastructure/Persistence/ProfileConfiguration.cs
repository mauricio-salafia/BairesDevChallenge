using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Persistence
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(x => x.ProfileId).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
            builder.Property(x => x.CurrentRole).HasMaxLength(255);
            builder.Property(x => x.NumberOfConnections);
            builder.Property(x => x.NumberOfRecommendations);
            builder.HasOne(c => c.Country).WithMany(x => x.Profiles).HasForeignKey(x => x.CountryId);
            builder.HasOne(i => i.Industry).WithMany(x => x.Profiles).HasForeignKey(x => x.IndustryId);
        }
    }
}
