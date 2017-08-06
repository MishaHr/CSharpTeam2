using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас категорій товарів. 
    /// </summary>
    public class Category: BaseEntity,IGetable,ISaveable,IComparable
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

        public override bool Equals(object cn)
        {
            if (cn == null)
            {
                return false;
            }
            Category obj = cn as Category;
            if ((object)obj == null)
            {
                return false;
            }
            int cat1 = this.CategoryId;
            int cat2 = obj.CategoryId;
            return (cat1 == cat2) ? true : false;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
