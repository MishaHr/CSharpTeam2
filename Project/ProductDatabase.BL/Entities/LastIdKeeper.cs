using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    internal class LastIdKeeper:BaseEntity
    {

        internal int LastProductId { get; set; }
        public int LastCategoryId { get; set; }
        public int LastManufacturerId { get; set; }
        public int LastSupplierId { get; set; }

        public LastIdKeeper(int id): base(1)
        {
            
        }

        public override string ToString()
        {
            return string.Format($"{id};{LastCategoryId};{LastManufacturerId};{LastSupplierId}");
        }
    }
}
