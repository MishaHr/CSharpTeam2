using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL.Editors
{
    public class ManufacturerEditor
    {

        public ManufacturerEditor()
        {
            
        }
        public  void Add(string newName)
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            var lastIdKeeper = (LastIdKeeper)lastIdKeeperRepository.Get(1);
            int newId = lastIdKeeper.LastManufacturerId + 1;
            Manufacturer manufacturer = new Manufacturer(newId);
            manufacturer.IsNew = true;
            lastIdKeeper.IsChanged = true;
            manufacturer.ManufacturerName = newName;
            lastIdKeeper.LastManufacturerId = newId;
            lastIdKeeperRepository.Save(lastIdKeeper);
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
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            manufacturerRepository.Save(toSave);
        }
    }
}
