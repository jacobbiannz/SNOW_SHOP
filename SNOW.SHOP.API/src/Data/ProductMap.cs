using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.src.Model;


namespace SNOW.SHOP.API.Data
{
    public class ProductMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Product>();

            entity.ToTable("Product", "Production");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();

            entity.HasOne(a => a.Company).WithMany(s => s.AllProducts).HasForeignKey(a=>a.CompanyId);
            entity.HasOne(a => a.Category).WithMany(s => s.AllProducts).HasForeignKey(a => a.CategoryId);
            entity.HasOne(a => a.Brand).WithMany(s => s.AllProducts).HasForeignKey(a => a.BrandId);
        }
    }
}
