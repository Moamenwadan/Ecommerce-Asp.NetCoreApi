using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).HasColumnType("NVARCHAR(100)").HasMaxLength(100).IsRequired();
            builder.Property(P => P.Price).HasColumnType("DECIMAL(18,2)");
            builder.Property(P => P.PictureUrl).HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(P => P.Description).HasColumnType("NVARCHAR(MAX)").IsRequired();
            // one          to    many 
            // ProductType  to    products
            builder.HasOne(P => P.ProductType)
                .WithMany(PT => PT.Products).
                HasForeignKey(P => P.ProductTypeId)
.OnDelete(DeleteBehavior.SetNull);


            // one          to    many 
            // Brand  to    products
            builder.HasOne(P => P.ProductBrand).
                WithMany(Brand => Brand.Products).
                HasForeignKey(P => P.BrandId)
.OnDelete(DeleteBehavior.SetNull);



        }
    }
}
