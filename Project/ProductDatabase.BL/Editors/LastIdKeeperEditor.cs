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
