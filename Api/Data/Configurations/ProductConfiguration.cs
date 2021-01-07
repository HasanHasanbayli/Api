using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .HasMaxLength(50).IsRequired();

            builder.HasOne(m => m.User)
                .WithMany(m => m.Products)
                .HasForeignKey(m => m.UserId);

            builder.ToTable("Products");
        }
    }
}
