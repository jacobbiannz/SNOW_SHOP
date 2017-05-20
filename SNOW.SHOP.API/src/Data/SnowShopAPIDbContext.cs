using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SNOW.SHOP.API.Model;
using System;

namespace SNOW.SHOP.API.Data
{
    public class SnowShopAPIDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Product> Products { get; set; }

        public SnowShopAPIDbContext(IOptions<AppSettings> appSettings, IEntityMapper entityMapper)
        {
            ConnectionString = appSettings.Value.ConnectionString;

            EntityMapper = entityMapper;
        }

        public String ConnectionString { get; }

        public IEntityMapper EntityMapper { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityMapper.MapEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
