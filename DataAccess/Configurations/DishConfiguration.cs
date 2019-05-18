using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(d => d.Price)
                .IsRequired();
            builder.Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(d => d.Serving)
                .IsRequired();
            builder.Property(d => d.Ingredients)
                .IsRequired();
            builder.Property(d => d.CreatedAt)
                .HasDefaultValueSql("CURRENT_DATE()");
        }
    }
}