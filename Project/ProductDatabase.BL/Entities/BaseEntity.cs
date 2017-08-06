using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    public abstract class BaseEntity
    {
        internal bool IsNew { get; set; } = false;
        internal bool IsChanged { get; set; } = false;
        internal bool IsDeleted { get; set; } = false;

    }
}
