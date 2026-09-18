using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTOS
{
    public class BrandDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<ProductSummaryDto> Products { get; set; }=new List<ProductSummaryDto>();

    }
}
