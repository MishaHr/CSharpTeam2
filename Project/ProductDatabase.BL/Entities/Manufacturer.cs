using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    /// <summary>
    /// Клас Виробників продукції.
    /// </summary>
    internal class Manufacturer: BaseEntity
    {
        //internal static int id { get; private set; }
        public string ManufacturerName { get; set; }

        public Manufacturer(int id): base (id)
        {
            //id = manufacturerId;
        }

        public override string ToString()
        {
            return string.Format($"{id};{ManufacturerName}");
        }

        
    }
}
