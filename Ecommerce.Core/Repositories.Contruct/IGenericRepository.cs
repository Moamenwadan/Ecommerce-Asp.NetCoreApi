using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Repositories.Contruct
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey> 
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);

        Task AddAsync(TEntity Entity);

        void Update(TEntity Entity);

        void DeleteByEntity(TEntity TEntity);

        void DeleteById(TKey id);
 



    }
}
