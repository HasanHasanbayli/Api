using AcademyApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AcademyApi.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .HasMaxLength(50).IsRequired();

            builder.Property(m => m.Surname)
                .HasMaxLength(50).IsRequired();

            builder.Property(m => m.Email)
                .HasMaxLength(50).IsRequired();

            builder.Property(m => m.Password)
                .HasMaxLength(100).IsRequired();

            builder.Property(m => m.Token)
                .HasMaxLength(100);

            builder.ToTable("Users");
        }
    }
}