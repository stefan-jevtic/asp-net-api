using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIME()");
        }
    }
}