using AcademyApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyApi.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(m => m.User)
                .WithMany(m => m.Transactions)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Category)
                .WithMany(m => m.Transactions)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Amount)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(500);

            builder.ToTable("Transactions");
        }
    }
}