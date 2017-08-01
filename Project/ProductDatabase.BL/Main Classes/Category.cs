using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас категорій товарів. 
    /// </summary>
    public class Category: ISaveable
    {
        public int CategoryId { get; private set; }

        public string CategoryName { get; set; }

        /// <summary>
        /// Основний коснтруктор
        /// </summary>
        /// <param name="categoryId"></param>
        public Category (int categoryId)
        {
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return string.Format($"{CategoryId};{CategoryName}");
        }
    }
}
