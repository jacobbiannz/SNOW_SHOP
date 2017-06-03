using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.Data
{
    public class StoreMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.ToTable("Store", "Production");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
