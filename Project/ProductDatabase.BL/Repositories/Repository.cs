using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repositories
{
    internal class Repository <T> where T: BaseEntity
    { 
        private string _option;
        private List<BaseEntity> _list = new List<BaseEntity>();
        private List<T> _objectList = new List<T>();

        public Repository()
        {
            _option = typeof(T).Name;
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _list.Add(GetInstance(retrivedData[index]));
            }

        }


        internal  IEnumerable<BaseEntity> GetAll()
        {
            return _list;
        }

        internal  BaseEntity Get(int id)
        {
            BaseEntity manufacturer = _list.FirstOrDefault(man => man.id == id);
            return manufacturer;
        }

        internal  void Save(BaseEntity newData)
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

        protected internal  void Add(BaseEntity objectToAdd)
        {
            _list.Add((BaseEntity)objectToAdd);
            SaveTable();
        }

        protected internal  void Update(BaseEntity objectToUpdate)
        {
            var toAdd = objectToUpdate as T;
            _list.Add(toAdd);
            _list.Remove(toAdd);
            SaveTable();
        }

        protected internal  void Delete(BaseEntity objectToDelete)
        {
            var toDelete = objectToDelete as T;
            _list.Remove(toDelete);
            SaveTable();
        }

        protected internal  void SaveTable()
        {
            List<string> textList = new List<string>();
            foreach (var item in _list)
            {
                textList.Add(item.ToString());
            }
            SaveService save = new SaveService();
            save.WrightToFile(textList);
        }


        protected internal BaseEntity GetInstance (string[] retrivedData)
        {
            if (_option == "Manufacturer")
            {
                Manufacturer result = ObjectCreator.CreateManufacturer(retrivedData);
                return result;
            }
            else if (_option == "Supplier")
            {
                Supplier result = ObjectCreator.CreateSupplier(retrivedData);
                return result;
            }
            return null;
        }

       

       
        



    }
}
