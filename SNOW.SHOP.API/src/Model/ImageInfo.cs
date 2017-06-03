using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class ImageInfo : AuditableEntity<ImageInfo>
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Product Product { get; set; }
    }
}
