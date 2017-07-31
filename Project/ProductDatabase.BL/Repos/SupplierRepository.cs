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
    public class SupplierRepository
    {
        private string _option = "Supplier";
        private List<Supplier> _supplierList;

        public SupplierRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator(_option);
            _supplierList = new List<Supplier>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _supplierList.Add(itemCreator.GetSupplier(retrivedData[index]));
            }

        }


        /// <summary>
        /// Метод для добування о’єкту Supplier з бази даних. Приймає ID постачальника як вхідний параметр
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Повертає об’єкт класу Supplier з відповідни ID</returns>

        //метод зчитування всіх записів
        

        public void Save(string saveProduct)
        {
            SaveService.WrightToFile(saveProduct);
        }
    }

}
