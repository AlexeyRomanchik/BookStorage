using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStorage.Models;

namespace BookStorage.DbConfiguration.Configuration
{
    public class PublishingHouseConfiguration : IEntityTypeConfiguration<PublishingHouse>
    {
        public void Configure(EntityTypeBuilder<PublishingHouse> builder)
        {
            builder.ToTable("PublishingHouse");

            builder.Property(x => x.Name)
                .HasMaxLength(64)
                .IsUnicode()
                .IsRequired()
                .IsUnicode();
        }
    }
}
