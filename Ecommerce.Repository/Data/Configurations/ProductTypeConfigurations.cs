using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Data.Configurations
{
    public class ProductTypeConfigurations : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(PT => PT.Name).HasColumnType("NVARCHAR(100)").HasMaxLength(100).IsRequired();
            builder.Property(PT => PT.CategoryId).IsRequired();
builder.HasOne(PT=>PT.Category)
                .WithMany(C=>C.ProductTypes)
                .HasForeignKey(PT=>PT.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);  
                
                }
    }
}
