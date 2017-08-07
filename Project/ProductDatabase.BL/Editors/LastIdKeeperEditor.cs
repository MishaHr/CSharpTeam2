using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    internal static class LastIdKeeperEditor
    {
        public static void Edit(LastIdKeeper toSave)
        {
           Repository<LastIdKeeper> lastRepo = new Repository<LastIdKeeper>();
           lastRepo.Update(toSave); 
        }
    }
}
