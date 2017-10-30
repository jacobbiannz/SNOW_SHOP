using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SNOW.SHOP.API.src.Abstract;
using SNOW.SHOP.API.src.Model;
using SNOW.SHOP.API.src.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.Data
{
    public class CategoryRepository : EntityRepository<Category>, ICategoryRepository
    {
        private SnowShopAPIDbContext _context;

        public CategoryRepository(SnowShopAPIDbContext dbContext):base(dbContext)
        {
            _context = dbContext;
        }

        public override async Task<Category> AddAsync(Category entity)
        {
            entity.Company = _context.Companies.FirstOrDefault();
            EntityEntry dbEntityEntry = _context.Entry<Category>(entity);
            try {
                _context.Set<Category>().Add(entity);
                await CommitAsync();
            }
            catch(Exception e) {
                Console.WriteLine(e.InnerException);
            }
            
            return entity;
        }
    }
}
