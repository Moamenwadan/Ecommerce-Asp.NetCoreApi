using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Core.Entities
{
    public class Product : BaseEntity<int>
    {
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int? ProductTypeId {  get; set; } //FK
        public int? BrandId { get; set; } //FK


        public ProductType ProductType { get; set; }
        public Brand ProductBrand { get; set; }

    }
}
