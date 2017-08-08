using System.Collections.Generic;
using System.Linq;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repositories
{
    internal class Repository <T> where T: BaseEntity
    { 
        private string _option;
        private List<BaseEntity> _list = new List<BaseEntity>();

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

        internal  List<T> GetAll()
        {
            List<T> result = new List<T>();
            for (int index = 0; index < _list.Count(); index++)
            {
                result.Add(_list[index] as T);
            }
            return result;
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
            _list.Add(objectToAdd);
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
            if (_option == "Supplier")
            {
                Supplier result = ObjectCreator.CreateSupplier(retrivedData);
                return result;
            }
            if (_option == "Category")
            {
                Category result = ObjectCreator.CreateCategory(retrivedData);
                return result;
            }
            if (_option == "Memo")
            {
                Memo result = ObjectCreator.CreateMemo(retrivedData);
                return result;
            }
            if (_option == "ShortDescription")
            {
                ShortDescription result = ObjectCreator.CreateDescription(retrivedData);
                return result;
            }
            if (_option == "WarehouseRecord")
            {
                WarehouseRecord result = ObjectCreator.CreateWarehouseRecord(retrivedData);
                return result;
            }
            if (_option == "Product")
            {
                Product result = ObjectCreator.CreateProduct(retrivedData);
                return result;
            }
            if (_option == "LastIdKeeper")
            {
                LastIdKeeper result = ObjectCreator.CreateLastIdKeeper(retrivedData);
                return result;
            }
            return null;
        }
    }
}
