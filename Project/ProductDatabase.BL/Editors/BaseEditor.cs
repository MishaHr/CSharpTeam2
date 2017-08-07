using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public abstract class BaseEditor
    {



        //protected internal int GetLastId()
        //{
        //    LastIdKeeperRepository lastIdKeeperRepository = new LastIdKeeperRepository();
        //    var lastId = (List<LastIdKeeper>)lastIdKeeperRepository.GetAll();
        //    return lastId[0].LastCategoryId;
        //}

        //protected internal static void SaveLastId(int id)
        //{
        //    LastIdKeeperRepository lastIdKeeperRepository = new LastIdKeeperRepository();
        //    lastIdKeeperRepository.SaveChanges();
        //}

        //public override bool Equals(object cn)
        //{
        //    if (cn == null)
        //    {
        //        return false;
        //    }
        //    IGetable obj = cn as IGetable;
        //    if ((object)obj == null)
        //    {
        //        return false;
        //    }
        //    int cat1 = this.id;
        //    int cat2 = obj.id;
        //    return (cat1 == cat2) ? true : false;
        //}

        //public override int GetHashCode()
        //{
        //    return id;
        //}
    }
}
