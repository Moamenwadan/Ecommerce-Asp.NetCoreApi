using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Core.Entities
{
    public class ProductType : BaseEntity<int>
    {
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
        public int? CategoryId { get; set; } // FK صريح
        public Category Category { get; set; }


        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
