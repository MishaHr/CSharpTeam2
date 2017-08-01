using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Main_Classes
{
    /// <summary>
    /// Клас Виробників продукції.
    /// </summary>
    public class Manufacturer: ISaveable
    {
        public int ManufacturerId { get; private set; }
        public string ManufacturerName { get; set; }

        public Manufacturer(int manufacturerId)
        {
            ManufacturerId = manufacturerId;
        }

        public override string ToString()
        {
            return string.Format($"{ManufacturerId};{ManufacturerName}");
        }
    }
}
