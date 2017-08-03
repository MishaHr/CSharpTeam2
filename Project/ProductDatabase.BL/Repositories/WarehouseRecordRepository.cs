using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repos
{
    public class WarehouseRecordRepository:IRepository
    {
        private string _option = "WarehouseRecord";
        private List<WarehouseRecord> _warehouseRecordsList;
        public WarehouseRecordRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator();
            _warehouseRecordsList = new List<WarehouseRecord>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _warehouseRecordsList.Add(itemCreator.CreateWarehouseRecord(retrivedData[index]));
            }
        }

        public IEnumerable<IGetable> GetAll()
        {
            List<WarehouseRecord> warehouseRecords = _warehouseRecordsList;
            return warehouseRecords;
        }

        public IGetable Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(IGetable newObject)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
