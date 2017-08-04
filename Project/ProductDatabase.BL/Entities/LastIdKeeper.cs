using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    internal class LastIdKeeper:IGetable,ISaveable
    {
        public int LastProductId { get; set; }
        public int LastCategoryId { get; set; }
        public int LastManufacturerId { get; set; }
        public int LastSupplierId { get; set; }

        public override string ToString()
        {
            return string.Format($"{LastProductId};{LastCategoryId};{LastManufacturerId};{LastSupplierId}");
        }
    }
}
