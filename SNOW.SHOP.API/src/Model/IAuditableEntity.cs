﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SNOW.SHOP.API.Model
{
    public interface IAuditableEntity
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}
