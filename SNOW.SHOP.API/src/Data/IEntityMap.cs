using Microsoft.EntityFrameworkCore;

namespace SNOW.SHOP.API.Data
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}
