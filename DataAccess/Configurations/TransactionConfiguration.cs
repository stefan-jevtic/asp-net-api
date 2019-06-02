using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Amount)
                .IsRequired();
            builder.Property(t => t.Type)
                .IsRequired();
            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIME()");
            
        }
    }
}