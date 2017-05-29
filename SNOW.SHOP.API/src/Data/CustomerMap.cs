using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.Model;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.Data
{
    public class CustomerMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();

            entity.ToTable("Cutomer", "Production");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
