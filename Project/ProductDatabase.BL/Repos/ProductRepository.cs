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
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product newProduct);
        void SaveChanes();
    }

    /// <summary>
    /// Клас для добування Продуктів
    /// </summary>
    public class ProductRepository: IProductRepository
    {
        private string _option = "Product";
        private List<Product> _productList;

        public ProductRepository() 
        {
           LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator(_option);
            _productList = new List<Product>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
               _productList.Add(itemCreator.GetProduct(retrivedData[index]));
            }
        }

        //метод зчитування всіх записів
       
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = _productList;
            return products;
        }

        public Product Get(int id)
        {
            Product item = _productList.FirstOrDefault(product => product.ProductId == id);
            return item;
        }

        public Product Add(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public void SaveChanes()
        {
            throw new NotImplementedException();
        }
    }

}
