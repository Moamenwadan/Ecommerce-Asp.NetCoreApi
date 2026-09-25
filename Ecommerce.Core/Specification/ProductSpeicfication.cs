using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Core.Specification
{
    /*
    public class ProductSpeicfication : ISpecification<Product, int>
    {
        public Expression<Func<Product, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<Product, object>>> Includes { get; set; } = new List<Expression<Func<Product, object>>>();
        public ProductSpeicfication()
        {
            Includes.Add(p=>p.ProductType);
            Includes.Add(p => p.ProductBrand);
        }

        public ProductSpeicfication(Expression<Func<Product, bool>> expression)
        {
            Criteria = expression;
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.ProductBrand);
        }
    }
    */

    public class ProductSpeicfication : Specification<Product, int>
    {

        public ProductSpeicfication(Expression<Func<Product, bool>> expression)
        {
            Criteria = expression;
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.ProductBrand);
        }

        public ProductSpeicfication()
        {
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.ProductBrand);
        }

     
    }


}
