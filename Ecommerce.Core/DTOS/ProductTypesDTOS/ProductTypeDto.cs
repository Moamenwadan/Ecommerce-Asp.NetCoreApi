using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Core.DTOS.ProductTypesDTOS
{
    public class ProductTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ProductSummaryDto> Products { get; set; } = new List<ProductSummaryDto>();


    }
}
