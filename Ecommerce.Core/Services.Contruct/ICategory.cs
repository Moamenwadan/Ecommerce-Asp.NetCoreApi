using Ecommerce.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface ICategory
    {
       Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();

        Task<CategoryDto> GetCategoryById(int id);

    }
}
