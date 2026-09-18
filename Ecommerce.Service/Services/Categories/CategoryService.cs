using AutoMapper;
using Ecommerce.Core;
using Ecommerce.Core.DTOS.CategoryDTOS;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Services.Contruct;
using Ecommerce.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Services.Categories
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var category  = await _unitOfWork.Repository<Category,int>().GetAllAsync();
            var categorydto = _Mapper.Map<IEnumerable<CategoryDto>>(category);
            return categorydto;


        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _unitOfWork.Repository<Category, int>().GetByIdAsync(id);
            var categorydto = _Mapper.Map<CategoryDto>(category);
            return categorydto;
        }
    }
}
