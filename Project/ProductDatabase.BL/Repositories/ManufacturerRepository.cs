using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Repositories;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Entities
{
   /// <summary>
    /// Клас для добування Виробників
    /// </summary>
    internal class ManufacturerRepository:BaseRepository
    {
        //змінна вибору відповідного файлу бази даних (пізніше перероблю механізм)
        private string _option = "Manufacturer";

        private List<Manufacturer> _list = new List<Manufacturer>();
        public ManufacturerRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
           

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _list.Add(ObjectCreator.CreateManufacturer(retrivedData[index]));
            }
        }


         internal override IEnumerable<BaseEntity> GetAll()
        {
            List<Manufacturer> manufacturers = _list;
            return manufacturers;
        }

         internal override BaseEntity Get(int id)
        {
            Manufacturer manufacturer = _list.FirstOrDefault(man => man.id == id);
            return manufacturer;
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
            _list.Add((Manufacturer)objectToAdd);
            SaveTable();
        }

        protected internal override void Update(BaseEntity objectToUpdate)
        {
            Manufacturer toAdd = objectToUpdate as Manufacturer;
            _list.Add(toAdd);
            _list.Remove(toAdd);
            SaveTable();
        }

        protected internal override void Delete(BaseEntity objectToDelete)
        {
            Manufacturer toDelete = objectToDelete as Manufacturer;
            _list.Remove(toDelete);
            SaveTable();
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
    }
}
