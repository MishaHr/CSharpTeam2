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
    public class ProductRepository: IRepository
    {
        private string _option = "Product";
        private List<Product> _productList;

        public ProductRepository() 
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            
            _productList = new List<Product>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
               _productList.Add(ObjectCreator.CreateProduct(retrivedData[index]));
            }
        }

        //метод зчитування всіх записів
       
        public IEnumerable<IGetable> GetAll()
        {
            List<Product> products = _productList;
            return products;
        }

        public IGetable Get(int id)
        {
            Product item = _productList.FirstOrDefault(product => product.ProductId == id);
            return item;
        }

        public void Add(IGetable newProduct)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

}
