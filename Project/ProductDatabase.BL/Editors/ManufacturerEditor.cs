using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class ManufacturerEditor:BaseEditor
    {

        public ManufacturerEditor()
        {
            
        }
        public  void Add(string newName)
        {
            int newId = GetLastId() + 1;
            Manufacturer manufacturer = new Manufacturer(newId);
            manufacturer.IsNew = true;
            manufacturer.ManufacturerName = newName;
            SaveLastId(newId);
            SaveChanges(manufacturer);

        }

        public  void Edit(int id, string newName)
        {
            Manufacturer toEdit = new Manufacturer(id);
            toEdit.ManufacturerName = newName;
            toEdit.IsChanged = true;
            SaveChanges(toEdit);

        }

        public  void Delete(int id)
        {
            Manufacturer toDelete = new Manufacturer(id);
            toDelete.IsDeleted = true;
            SaveChanges(toDelete);
        }

        private void SaveChanges(BaseEntity toSave)
        {
            Repository<Manufacturer> manufacturerRepositoryRepository = new Repository<Manufacturer>();
            manufacturerRepositoryRepository.Save(toSave);
        }

        protected internal int GetLastId()
        {
            LastIdKeeperRepository lastIdKeeperRepository = new LastIdKeeperRepository();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            return lastId.LastManufacturerId;
        }

        protected internal static void SaveLastId(int id)
        {
            LastIdKeeperRepository lastIdKeeperRepository = new LastIdKeeperRepository();
            var lastId = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            lastId.LastManufacturerId = id;
            lastId.IsChanged = true;
            LastIdKeeperEditor.Edit(lastId);
        }
    }
}
