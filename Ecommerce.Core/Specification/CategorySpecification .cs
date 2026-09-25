using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Core.Specification
{
   public  class CategorySpecification : Specification<Category, int>
    {
        public CategorySpecification(Expression<Func<Category, bool>> expression)
        {
            Criteria = expression;
            Includes.Add(c => c.ProductTypes);
        }

        public CategorySpecification()
        {
            Includes.Add(c => c.ProductTypes);
        }
    }
}
