using System;
using System.Collections.Generic;
using System.Text;

namespace SNOW.SHOP.API.src.Model
{
    public abstract class BaseEntity
    {

    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual int Id { get; set; }
    }
}
