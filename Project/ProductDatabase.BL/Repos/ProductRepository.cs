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
    public class ProductRepository:AbstractRepository
    {
        
        public ProductRepository() : base("Product")
        {
           
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
