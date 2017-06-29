using System;
using System.Collections.Generic;
using System.Text;

namespace SNOW.SHOP.API.src.Model
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}
