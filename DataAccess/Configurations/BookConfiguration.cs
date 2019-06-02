using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(d => d.Price)
                .IsRequired();
            builder.Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(d => d.Pages)
                .IsRequired();
            builder.Property(d => d.Description)
                .IsRequired();
            builder.Property(d => d.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIME()");
        }
    }
}