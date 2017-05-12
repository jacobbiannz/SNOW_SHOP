using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SNOW.SHOP.API.Data
{
    public interface IEntityMapper
    {
        IEnumerable<IEntityMap> Mappings { get; }

        void MapEntities(ModelBuilder modelBuilder);
    }
}
