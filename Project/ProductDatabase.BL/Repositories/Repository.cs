using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repositories
{
    internal class Repository <T>
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

        protected internal BaseEntity GetInstance (string[] retrivedData)
        {
            if (_option == "Manufacturer")
            {
                Manufacturer result = CreateManufacturer(retrivedData);
                return result;
            }
            return null;
        }

        protected internal  Manufacturer CreateManufacturer(string[] retrivedData)
        {
            Manufacturer manufacturer = new Manufacturer(Convert.ToInt32(retrivedData[0]));
            manufacturer.ManufacturerName = retrivedData[1].Trim();
            return manufacturer;
        }

        protected internal  IEnumerable<BaseEntity> GetAll()
        {
            return _list;
        }



    }
}
