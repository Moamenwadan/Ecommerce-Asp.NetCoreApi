using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Core.Specification
{
    public class Specification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();

   
   
        public Expression<Func<TEntity, object>> OrderByDescending { get;  set; }
        public Expression<Func<TEntity, object>> OrderBy { get;  set; }

        public int Skip { get; set; }

        public int Take { get; set; }
        public bool IsEnablePagination { get; set; }


        public Specification(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }
        public Specification()
        {
            
        }
   
    }
}
