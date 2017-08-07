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
    internal class Category: BaseEntity
        {
        

        public string CategoryName { get; set; }

        /// <summary>
        /// Основний коснтруктор
        /// </summary>
        /// <param name="categoryId"></param>
        internal Category (int id):base(id)
        {
           
        }

        public override string ToString()
        {
            return string.Format($"{id};{CategoryName}");
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
            int cat1 = this.id;
            int cat2 = obj.id;
            return (cat1 == cat2) ? true : false;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
