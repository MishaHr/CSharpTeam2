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
    internal class LastIdKeeperRepository:BaseRepository
    {
        private string _option = "LastIdKeeper";
        private List<LastIdKeeper> _list;

        public LastIdKeeperRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();
            _list= new List<LastIdKeeper>();

            for (int i = 0; i<retrivedData.Count;i++)
            {
                _list.Add(CreateLastIdKeeper(retrivedData[i]));
            }

        }

         internal override IEnumerable<BaseEntity> GetAll()
        {
            return _list;
        }

        internal override BaseEntity Get(int id)
        {
            LastIdKeeper lastIdKeeper = _list.FirstOrDefault(li=>li.id==id);
            return lastIdKeeper;
        }

        internal override void Save(BaseEntity newData)
        {
            if (newData.IsChanged)
            {
                Update(newData);
            }
            else if (newData.IsNew)
            {
                Add(newData);
            }
            else if (newData.IsDeleted)
            {
                Delete(newData);
            }
        }

        protected internal override void Add(BaseEntity objectToAdd)
        {
            
        }

        protected internal override void Update(BaseEntity objectToUpdate)
        {
            LastIdKeeper toAdd = objectToUpdate as LastIdKeeper;
            _list.Add(toAdd);
            _list.Remove(toAdd);
            SaveTable();
        }

        protected internal override void Delete(BaseEntity objectToDelete)
        {
            throw new NotImplementedException();
        }


        protected internal override void SaveTable()
        {
            List<string> textList = new List<string>();
            foreach (var item in _list)
            {
                textList.Add(item.ToString());
            }
            SaveService save = new SaveService();
            save.WrightToFile(textList);
        }

        private LastIdKeeper CreateLastIdKeeper(string[] retrivedData)
        {
            LastIdKeeper lastIdKeeper = new LastIdKeeper(Convert.ToInt32(retrivedData[0]));
            lastIdKeeper.LastProductId = ToInt32(retrivedData[1]);
            lastIdKeeper.LastCategoryId = ToInt32(retrivedData[2]);
            lastIdKeeper.LastManufacturerId = ToInt32(retrivedData[3]);
            lastIdKeeper.LastSupplierId = ToInt32(retrivedData[4]);
            return lastIdKeeper;
        }

    }
}
