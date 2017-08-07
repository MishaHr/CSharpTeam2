using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    internal abstract class BaseEntity
    {
        internal int id { get; private set; }
        internal bool IsNew { get; set; } = false;
        internal bool IsChanged { get; set; } = false;
        internal bool IsDeleted { get; set; } = false;

        internal BaseEntity(int id)
        {
            this.id = id;
        }

        public override bool Equals(object cn)
        {
            if (cn == null)
            {
                return false;
            }
            BaseEntity obj = cn as BaseEntity;
            if ((object)obj == null)
            {
                return false;
            }
            int cat1 = this.id;
            int cat2 = obj.id;
            return (cat1 == cat2) ? true : false;
        }

        public override int GetHashCode()
        {
            return id;
        }
    }
}
