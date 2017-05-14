using System;
using System.Collections.Generic;
using System.Text;

namespace SNOW.SHOP.API.Data
{
    public class SNOWAPIEntityMapper : EntityMapper
    {
        public SNOWAPIEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new ProductMap() as IEntityMap
            };
        }
    }
}
