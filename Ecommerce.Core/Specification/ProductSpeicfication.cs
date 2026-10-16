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

        public ProductSpeicfication(string? sort,int?brandId,int?typeId, int PageIndex, int PageSize) :base(
            p=>
            (!brandId.HasValue || p.BrandId == brandId )&&(!typeId.HasValue || p.ProductTypeId ==typeId)
            )
        // p=> p.BrandId == 2 &&  p.ProductTypeId ==3 
        {
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.ProductBrand);

            switch (sort?.ToLower())
            {
                case "priceasc":
                    OrderBy = p => p.Price;
                    break;
                case "pricedesc":
                    OrderByDescending = p => p.Price;
                    break;
                default:
                    OrderBy = p => p.Id;
                    break;
            }
        
            if (PageSize > 0 && PageIndex > 0)
            {
                IsEnablePagination = true;
                Skip = PageSize * (PageIndex - 1);
                Take = PageSize;
            }
            //100 products
            // 10 * (1-1) = 0  products.Skip(0).Take(10) the  10 produts  FROM 100 Product
            //10 * (2-1) = 10  products.skip(10).take(10) the  10 produts FROM 90 Product
            //10 * (3-1) = 20  products.skip(20).take(10) the  10 produts FROM 80 Product

        }

    }


}
