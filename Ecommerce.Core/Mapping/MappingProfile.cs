using AutoMapper;
using Ecommerce.Core.DTOS;
using Ecommerce.Core.DTOS.BrandDTO;
using Ecommerce.Core.DTOS.CategoryDTOS;
using Ecommerce.Core.DTOS.ProductsDTOS;
using Ecommerce.Core.DTOS.ProductTypesDTOS;
using Ecommerce.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile(IConfiguration Configuration)
        {
            CreateMap<Category, CategoryDto>();
         
            CreateMap<ProductType, ProductTypeDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));
            CreateMap<Brand, BrandDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductTypeName, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d=>d.PictureUrl,o => o.MapFrom(s => $"{Configuration["BASEURL"]}{s.PictureUrl}"));


            CreateMap<Product, ProductSummaryDto>();
            CreateMap<ProductType, ProductTypeSummaryDto>();

        }
    }
}
