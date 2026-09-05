using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Data.Configurations
{
    public class BrandConfigurations:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(C => C.Name).HasColumnType("NVARCHAR(100)").HasMaxLength(100).IsRequired();

        }
    }
}
