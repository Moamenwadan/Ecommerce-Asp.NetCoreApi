using Ecommerce.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IBrand
    {
        Task<IEnumerable<BrandDto>> GetAllBrandAsync();
        Task<BrandDto> GetBrandById(int id);


    }
}
