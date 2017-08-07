using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас Продукції. містить основну інформацію про продук, а також ID категорії та виробника
    /// </summary>
    internal class Product: BaseEntity
    {
        
       
        public int CategoryId { get; set; }
        public int ManufacrirerId { get; set; }
        public string ProductModel { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ExpirationDate { get; set; } = "Необмежений";


        /// <summary>
        /// Основний конструктор, який буде використовуватись
        /// </summary>
        /// <param name="productId"></param>
        public Product(int id):base (id)
        {
           
        }

        /// <summary>
        /// Формат виводу стрінги в ToString() перевантажено у відповідності до формату запису у файл
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{id};{CategoryId};{ManufacrirerId};{ProductModel};{ProductionDate.ToString("dd.MM.yyyy")};{ExpirationDate}");
        }
    }
}
