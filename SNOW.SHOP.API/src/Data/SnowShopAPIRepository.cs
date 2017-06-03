using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.Data
{
    public class SnowShopAPIRepository : ISnowShopAPIRepository
    {
        private readonly SnowShopAPIDbContext DbContext;
        private Boolean Disposed;

        public SnowShopAPIRepository(SnowShopAPIDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }
        #region product
        public IQueryable<Product> GetProducts(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Product>().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Name.ToLower().Contains(name.ToLower()));
            }

            return query;
        }

        public Task<Product> GetProductAsync(Product entity)
        {
            return DbContext.Set<Product>().FirstOrDefaultAsync(item => item.Id == entity.Id);
        }

        public async Task<Product> AddProductAsync(Product entity)
        {
            entity.Name = entity.Name;
            entity.Description = entity.Description;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "user";


            DbContext.Set<Product>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> UpdateProductAsync(Product changes)
        {
            var entity = await GetProductAsync(changes);

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = "user";

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Product> DeleteProductAsync(Product changes)
        {
            var entity = await GetProductAsync(changes);

            if (entity != null)
            {
                DbContext.Set<Product>().Remove(entity);

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }
        #endregion

        #region category
        public IQueryable<Category> GetCategories(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Category>().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Name.ToLower().Contains(name.ToLower()));
            }

            return query;
        }

        public Task<Category> GetCategoryAsync(Category entity)
        {
            return DbContext.Set<Category>().FirstOrDefaultAsync(item => item.Id == entity.Id);
        }

        public async Task<Category> AddCategoryAsync(Category entity)
        {
            entity.Name = entity.Name;
            entity.Company = entity.Company;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "user";


            DbContext.Set<Category>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Category> UpdateCategoryAsync(Category changes)
        {
            var entity = await GetCategoryAsync(changes);

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Company = changes.Company;

                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = "user";

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Category> DeleteCategoryAsync(Category changes)
        {
            var entity = await GetCategoryAsync(changes);

            if (entity != null)
            {
                DbContext.Set<Category>().Remove(entity);

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }


        #endregion
    }
}
