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
                new ProductMap() as IEntityMap,
                new BrandMap() as IEntityMap,
                new CompanyMap() as IEntityMap,
                new PromotionMap() as IEntityMap,
                new OrderDetailMap() as IEntityMap,
                new ImageInfoMap() as IEntityMap,
                new CategoryMap() as IEntityMap,
                new InventoryMap() as IEntityMap,
                new PhotoMap() as IEntityMap,
                new SizeMap() as IEntityMap,
                new StoreMap() as IEntityMap,
                new OrderMap() as IEntityMap,
                new CustomerMap() as IEntityMap,
                new ReceiptMap() as IEntityMap,
                new OrderStatusMap() as IEntityMap,
                new PaymentTypeMap() as IEntityMap,
                new PromotionOrderMap() as IEntityMap,
                new PromotionProductMap() as IEntityMap
            };
        }
    }
}
