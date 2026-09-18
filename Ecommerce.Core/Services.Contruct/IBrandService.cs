using Ecommerce.Core.DTOS.BrandDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services.Contruct
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrandAsync();
        Task<BrandDto> GetBrandById(int id);


    }
}
