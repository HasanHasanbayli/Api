using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(m => m.Category)
                .WithMany(m => m.ProductCategories)
                .HasForeignKey(m => m.CategoryId);

            builder.HasOne(m => m.Product)
               .WithMany(m => m.ProductCategories)
               .HasForeignKey(m => m.ProductId);

            builder.ToTable("ProductCategories");
        }
    }
}