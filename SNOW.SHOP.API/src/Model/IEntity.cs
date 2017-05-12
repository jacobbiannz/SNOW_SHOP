using System;
using System.Collections.Generic;
using System.Text;

namespace SNOW.SHOP.API.Model
{
    public interface IEntity<T>
    {
        int Id { get; set; }
    }
}
