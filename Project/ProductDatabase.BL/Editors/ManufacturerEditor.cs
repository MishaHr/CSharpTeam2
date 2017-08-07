using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public static class ManufacturerEditor
    {
        public static void Add()
        {
            Repository<Manufacturer> manuf = new Repository<Manufacturer>();
        }
    }
}
