using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.Data
{
    public class InventoryMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Inventory>();

            entity.ToTable("Inventory", "Production");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
