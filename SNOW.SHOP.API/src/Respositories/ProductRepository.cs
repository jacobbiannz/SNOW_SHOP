using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        private Boolean Disposed;
       
        public ProductRepository(SnowShopAPIDbContext dbContext):base(dbContext)
        {  
        }

    }
}
