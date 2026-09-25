using Ecommerce.Core.Entities;
using Ecommerce.Core.Specification;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Core
{
    public class SpecificationEvaluator<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQury,ISpecification<TEntity,Tkey> spec)
        {
            if (spec.Criteria is not null)
            {
                InputQury = InputQury.Where(spec.Criteria);
            }
            foreach (var i in spec.Includes) {
                InputQury = InputQury.Include(i);
            }
            return InputQury;
        }
    }
}
