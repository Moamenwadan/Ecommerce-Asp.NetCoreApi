using Ecommerce.Core.Repositories.Contruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public interface IUnitOfWork
    {
        // function for SaveChanges
        Task<int> SaveChanges();
        // function For Create new Intance From Repositories if  I Need
        IGenericRepository<TEntity,TKey>  Repository<TEntity, TKey>();
    }
}
