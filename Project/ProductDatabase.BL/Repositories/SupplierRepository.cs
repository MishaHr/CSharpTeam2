using ProductDatabase.DA;
using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас для добування Постачальників з бази даних
    /// </summary>
    public class SupplierRepository:IRepository
    {
        private string _option = "Supplier";
        private List<Supplier> _supplierList;

        public SupplierRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            _supplierList = new List<Supplier>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _supplierList.Add(ObjectCreator.CreateSupplier(retrivedData[index]));
            }

        }

        /// <summary>
        /// Повертає повний список всіх постачальників
        /// </summary>
        /// <returns>Ліст постачальників</returns>
        public IEnumerable<IGetable> GetAll()
        {
            return _supplierList;
        }

        /// <summary>
        /// Метод для добування о’єкту Supplier з бази даних.
        /// </summary>
        /// <param name="productId">ID постачальника</param>
        /// <returns>Об’єкт класу Supplier з відповідни ID</returns>
        public IGetable Get(int id)
        {
            Supplier supplier = _supplierList.FirstOrDefault(s => s.SupplierId == id);
            return supplier;
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
