using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStorage.Models;

namespace BookStorage.DbConfiguration.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.Property(x => x.Name)
                .HasMaxLength(124)
                .IsUnicode()
                .IsRequired();
            builder.Property(x => x.Surname)
                .HasMaxLength(124)
                .IsUnicode()
                .IsRequired();
        }
    }
}
