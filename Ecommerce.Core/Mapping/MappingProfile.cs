using AutoMapper;
using Ecommerce.Core.DTOS;
using Ecommerce.Core.DTOS.BrandDTO;
using Ecommerce.Core.DTOS.CategoryDTOS;
using Ecommerce.Core.DTOS.ProductsDTOS;
using Ecommerce.Core.DTOS.ProductTypesDTOS;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
         
            CreateMap<ProductType, ProductTypeDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
            CreateMap<Brand, BrandDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductTypeName, o => o.MapFrom(s => s.ProductType.Name));


            CreateMap<Product, ProductSummaryDto>();
            CreateMap<ProductType, ProductTypeSummaryDto>();

        }
    }
}
