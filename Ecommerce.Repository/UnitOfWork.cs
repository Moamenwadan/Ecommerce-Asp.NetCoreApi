using Ecommerce.Core;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories.Contruct;
using Ecommerce.Repository.Data.Contexts;
using Ecommerce.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;// Product
            if (!_repositories.ContainsKey(type))
            {
            var repository = new GenericRepository<TEntity, TKey> (_context);
            _repositories.Add(type, repository);
            }
            return (IGenericRepository<TEntity, TKey>)_repositories[type];


            //forEach(var item in _repositories.key){
            //if(item != "Product")
            // var repository = new GenericRepository<TEntity, TKey> (_context);
            // _repositories.Add(type, repository);
            //} 
        }

        public async Task<int> SaveChanges()
        {
          return  await _context.SaveChangesAsync();
                
        }
    }
}
