using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repositories
{
    internal class LastIdKeeperRepository:IRepository,ISaveable
    {
        private string _option = "LastIdKeeper";
        private List<LastIdKeeper> _lastIdKeeperList;

        public LastIdKeeperRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();
            _lastIdKeeperList= new List<LastIdKeeper>();

            for (int i = 0; i<retrivedData.Count;i++)
            {
                _lastIdKeeperList.Add(CreateLastIdKeeper(retrivedData[i]));
            }

        }

        public IEnumerable<IGetable> GetAll()
        {
            return _lastIdKeeperList;
        }

        public IGetable Get(int id)
        {
            LastIdKeeper lastIdKeeper = _lastIdKeeperList.FirstOrDefault(li=>li.LastProductId==id);
            return lastIdKeeper;
        }

        public void Add(IGetable newObject)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        private LastIdKeeper CreateLastIdKeeper(string[] retrivedData)
        {
            LastIdKeeper lastIdKeeper = new LastIdKeeper();
            lastIdKeeper.LastProductId = ToInt32(retrivedData[0]);
            lastIdKeeper.LastCategoryId = ToInt32(retrivedData[1]);
            lastIdKeeper.LastManufacturerId = ToInt32(retrivedData[2]);
            lastIdKeeper.LastSupplierId = ToInt32(retrivedData[3]);
            return lastIdKeeper;
        }
    }
}
