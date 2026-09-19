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
    }
}
