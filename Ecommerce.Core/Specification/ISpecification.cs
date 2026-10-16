using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ecommerce.Core.Specification
{
    public interface ISpecification<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Expression<Func<TEntity, bool>> Criteria { get; set; }
      List<Expression<Func<TEntity, object>>> Includes { get; set; }

        Expression<Func<TEntity, object>> OrderBy { get; set; }
        Expression<Func<TEntity, object>> OrderByDescending { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsEnablePagination { get; set; }


    }
}
