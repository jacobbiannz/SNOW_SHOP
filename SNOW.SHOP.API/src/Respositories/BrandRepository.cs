using SNOW.SHOP.API.Data;
using SNOW.SHOP.API.src.Abstract;
using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Respositories
{
    public class BrandRepository : EntityRepository<Brand>, IBrandRepository
    {
        public BrandRepository(SnowShopAPIDbContext dbContext):base(dbContext)
        {
        }
    }
}
