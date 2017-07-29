using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProductDatabase.DA;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас для добування Продуктів
    /// </summary>
    public class ProductRepository:IRepository
    {
        //змінна вибору відповідного файлу бази даних (пізніше перероблю механізм)
        public string Option { get; set; } = "Product";

        /// <summary>
        ///  Метод для добування о’єкту Product з бази даних. Приймає ID продукту як вхідний параметр
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Повертає об’єкт класу Product з відповідни ID</returns>
        public IRetrivable Retrive(int Id)
        {
            
            //читаєму інфу з файлу
            LoadService load = new LoadService(Option);
            string [] retrivedData = load.ReadFromFile(Id);
           
            
            //заповнюємо відповідні поля в об’єкту Product
            Product item = new Product(ToInt32(retrivedData [0]));
            item.CategoryId = ToInt32(retrivedData[1]);
            item.ManufacrirerId = ToInt32(retrivedData[2]);
            item.ProductModel = retrivedData[3];


            return item;
        }

        //метод зчитування всіх записів
        //public List<Product> RetriveAll()
        //{
        //    List<Product> productList = new List<Product>() { };
        //    LoadService load = new LoadService(Option);
        //    List<string[]> retrivedData = load.ReadAll();

        //    foreach (var prod in retrivedData)
        //    {
        //        int productID = Convert.ToInt32(prod[0]);
        //        productList.Add(new Product(productID, prod[1]));
        //    }

        //    return productList;
        //}

        public void Save(string saveProduct)
        {
            SaveService.WrightToFile(saveProduct);
        }
    }

}
