using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTOS.CategoryDTOS
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductTypeSummaryDto> ProductTypes { get; set; } = new List<ProductTypeSummaryDto>();
    }
}
