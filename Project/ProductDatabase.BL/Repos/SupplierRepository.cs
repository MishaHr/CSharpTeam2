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
        private string option = "Supplier";

        /// <summary>
        /// Метод для добування о’єкту Supplier з бази даних. Приймає ID постачальника як вхідний параметр
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Повертає об’єкт класу Supplier з відповідни ID</returns>
        public Supplier Retrive(int productId)
        {

            //читаєму інфу з файлу
            LoadService load = new LoadService(option);
            string[] supplierData = load.ReadFromFile(productId);


            //заповнюємо відповідні поля в об’єкту Supplier
            Supplier item = new Supplier(ToInt32(supplierData[0]));
            item.SupplierName = supplierData[1];

            return item;
        }
    
        //метод зчитування всіх записів
        public List<Supplier> RetriveAll()
        {
            List<Supplier> supplierList = new List<Supplier>() { };
            LoadService load = new LoadService(option);
            List<string[]> retrivedData = load.ReadAll();

            foreach (var sup in retrivedData)
            {
                int supplierID = Convert.ToInt32(sup[0]);
                supplierList.Add(new Supplier(supplierID, sup[1]));
            }

            return supplierList;
        }

        public void Save(string saveProduct)
        {
            SaveService.WrightToFile(saveProduct);
        }
    }

}
