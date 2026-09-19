using AutoMapper;
using Ecommerce.Core;
using Ecommerce.Core.DTOS.BrandDTO;
using Ecommerce.Core.DTOS.ProductTypesDTOS;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Services.Contruct;
using Ecommerce.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services.Brands
{
    public class BrandService:IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandAsync()
        {
            var brand = await _unitOfWork.Repository<Brand, int>().GetAllAsync();
            var branddto = _Mapper.Map<IEnumerable<BrandDto>>(brand);
            return branddto;
        }

        public async Task<BrandDto> GetBrandById(int id)
        {
            var brand = await _unitOfWork.Repository<Brand, int>().GetByIdAsync(id);
            var branddto = _Mapper.Map<BrandDto>(brand);
            return branddto;
        }
    }
}
