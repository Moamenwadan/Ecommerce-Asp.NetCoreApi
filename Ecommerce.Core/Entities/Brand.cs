using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Entities
{
    public class Brand : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
