using AutoMapper;
using Ecommerce.Core;
using Ecommerce.Core.DTOS.ProductTypesDTOS;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Services.Contruct;
using Ecommerce.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services.ProductTypes
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;

        public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        public async Task<IEnumerable<ProductTypeDto>> GetAllProductTypeAsync()
        {
          var ProductType = await _unitOfWork.Repository<ProductType,int>().GetAllAsync();
            var producttypedto = _Mapper.Map<IEnumerable<ProductTypeDto>>(ProductType);
            return producttypedto; 

        }

        public async Task<ProductTypeDto> GetProductTypeById(int id)
        {
            var ProductType = await _unitOfWork.Repository<ProductType, int>().GetByIdAsync(id);
            var producttypedto = _Mapper.Map<ProductTypeDto>(ProductType);
            return producttypedto;
        }
    }
}
