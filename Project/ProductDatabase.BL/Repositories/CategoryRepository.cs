using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repos
{
    

    /// <summary>
    /// Клас для добування Категорій
    /// </summary>
    public class CategoryRepository: IRepository
    {
        private string _option  = "Category";
        private List<Category> _categoryList;

        public CategoryRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator(_option);
            _categoryList = new List<Category>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _categoryList.Add(itemCreator.CreateCategory(retrivedData[index]));
            }
        }

      
        public IEnumerable<IGetable> GetAll()
        {
            List <Category> categories = _categoryList;
            return categories;
        }

        public IGetable Get(int id)
        {
            Category item = _categoryList.FirstOrDefault(product => product.CategoryId == id);
            return item;
        }

        public void Add(IGetable newObject)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
