using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Core.Entities
{
    public class Category  : BaseEntity<int>
    {
        [Column(TypeName ="NVARCHAR(50)")]
        public string Name { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();

    }
}
