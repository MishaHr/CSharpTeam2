using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас Продукції. містить основну інформацію про продук, а також ID категорії та виробника
    /// </summary>
    public class Product:IRetrivable
    {
        
        public int ProductId { get; private set; }
        public int CategoryId { get; set; }
        public int ManufacrirerId { get; set; }
        public string ProductModel { get; set; }

    

        public Product()
        {
                
        }

        /// <summary>
        /// Основний конструктор, який буде використовуватись
        /// </summary>
        /// <param name="productId"></param>
        public Product(int productId)
        {
            ProductId = productId;
        }


        public override string ToString()
        {
            return string.Format($"ID:{ProductId} Category:{CategoryId} Manufacturer: {ManufacrirerId} Model {ProductModel}");
        }
    }
}
