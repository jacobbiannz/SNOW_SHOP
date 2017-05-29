using SNOW.SHOP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Photo : AuditableEntity<Photo>
    {
        public byte[] BinaryData { get; set; }

        public ImageInfo ImageInfo { get; set; }
    }
}
