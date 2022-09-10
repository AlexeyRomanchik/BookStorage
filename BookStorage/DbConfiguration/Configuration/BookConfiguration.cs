using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStorage.Models;

namespace BookStorage.DbConfiguration.Configuration
{
    public class BookConfiguration  : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(x => x.Name)
                .HasMaxLength(1024)
                .IsRequired()
                .IsUnicode();

            builder.Property(x => x.Description)
                .IsUnicode();

            builder.Property(x => x.PublicationDate)
                .IsRequired(false);

            builder.Property(x => x.Rating)
                .IsRequired(false);
        }
    }
}
