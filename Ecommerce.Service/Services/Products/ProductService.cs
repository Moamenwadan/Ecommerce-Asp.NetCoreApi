using AutoMapper;
using Ecommerce.Core;
using Ecommerce.Core.DTOS.ProductsDTOS;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Services.Contruct;
using Ecommerce.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var product = await _unitOfWork.Repository<Product, int>().GetAllAsync();
            var productdto = _Mapper.Map<IEnumerable<ProductDto>>(product);
            return productdto;
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(id);
            var productdto = _Mapper.Map<ProductDto>(product);
            return productdto;
        }
    }
}
