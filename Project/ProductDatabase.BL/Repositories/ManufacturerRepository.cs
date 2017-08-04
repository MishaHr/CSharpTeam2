using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Entities
{
   /// <summary>
    /// Клас для добування Виробників
    /// </summary>
    public class ManufacturerRepository:IRepository
    {
        //змінна вибору відповідного файлу бази даних (пізніше перероблю механізм)
        private string _option = "Manufacturer";

        private List<Manufacturer> _manufacturerList;
        public ManufacturerRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator();
            _manufacturerList = new List<Manufacturer>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _manufacturerList.Add(itemCreator.CreateManufacturer(retrivedData[index]));
            }
        }


        public IEnumerable<IGetable> GetAll()
        {
            List<Manufacturer> manufacturers = _manufacturerList;
            return manufacturers;
        }

        public IGetable Get(int id)
        {
            Manufacturer manufacturer = _manufacturerList.FirstOrDefault(man => man.ManufacturerId == id);
            return manufacturer;
        }

        public void Add(IGetable newManufacturer)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
