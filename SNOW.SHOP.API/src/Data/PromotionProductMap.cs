﻿using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.Data
{
    public class PromotionProductMap : IEntityMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PromotionProduct>();

            entity.ToTable("PromotionProduct", "Production");

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseSqlServerIdentityColumn();
        }
    }
}
