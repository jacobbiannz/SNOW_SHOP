using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Abstract
{
    public interface IProductRepository : IEntityRepository<Product> { }

    public interface ICategoryRepository : IEntityRepository<Category> { }

    public interface IBrandRepository : IEntityRepository<Brand> { }
}
