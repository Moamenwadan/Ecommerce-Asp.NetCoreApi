using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories.Contruct;
using Ecommerce.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly EcommerceDbContext _context;

        public GenericRepository(EcommerceDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Category))
            {
                return (IEnumerable<TEntity>)await _context.Categories
                    .Include(c => c.ProductTypes)
                    .ToListAsync();
            }
            else if (typeof(TEntity) == typeof(ProductType))
            {
                return (IEnumerable<TEntity>)await _context.ProductsType
                    .Include(pt => pt.Products)
                    .Include(pt => pt.Category)
                    .ToListAsync();
            }
            else if (typeof(TEntity) == typeof(Brand))
            {
                return (IEnumerable<TEntity>)await _context.Brands
                    .Include(b => b.Products)
                    .ToListAsync();
            }
            else if (typeof(TEntity) == typeof(Product))
            {
                return (IEnumerable<TEntity>)await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();

        }


        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Category))
            {
                return await _context.Categories
                    .Include(c => c.ProductTypes)
                    .FirstOrDefaultAsync(c => c.Id.Equals(id)) as TEntity;
            }
            else if (typeof(TEntity) == typeof(ProductType))
            {
                return await _context.ProductsType
                    .Include(pt => pt.Products)
                    .Include(pt => pt.Category)
                    .FirstOrDefaultAsync(pt => pt.Id.Equals(id)) as TEntity;
            }
            else if (typeof(TEntity) == typeof(Brand))
            {
                return (IEnumerable<TEntity>)await _context.Brands
                    .Include(b => b.Products)
                    .FirstOrDefaultAsync(b => b.Id.Equals(id)) as TEntity;
            }
            else if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .FirstOrDefaultAsync(p => p.Id == id as int?) as TEntity;

            }

          return    await _context.Set<TEntity>().FindAsync(id);
            //var entiry = await _context.Set<TEntity>().FindAsync(id);
            //if (entity != null)
            //{
            //    return entity;
            //}
            //else
            //{
            //    return null;
            //}

        }






        public async Task AddAsync(TEntity Entity)
        {
            await _context.AddAsync(Entity);

        }
        public void Update(TEntity Entity)
        {
            _context.Update(Entity);
        }
        public void DeleteByEntity(TEntity Entity)
        {
            _context.Remove(Entity);

        }
 



        public void DeleteById(TKey id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }
    }
}
