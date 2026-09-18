using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.DTOS
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int? ProductTypeId { get; set; } //FK
        public int? BrandId { get; set; } //FK

        public string? ProductTypeName { get; set; }

        public string? BrandName { get; set; }

        //public ProductType ProductType { get; set; }
        //public Brand ProductBrand { get; set; }
    }
}
