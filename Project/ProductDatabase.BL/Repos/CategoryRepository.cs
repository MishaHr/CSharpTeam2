using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Repos
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        Category Add(Category newProduct);
        void SaveChanes();
    }

    /// <summary>
    /// Клас для добування Категорій
    /// </summary>
    public class CategoryRepository: ICategoryRepository
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
                _categoryList.Add(itemCreator.GetCategory(retrivedData[index]));
            }
        }

      
        public IEnumerable<Category> GetAll()
        {
            List <Category> categories = _categoryList;
            return categories;
        }

        public Category Get(int id)
        {
            Category item = _categoryList.FirstOrDefault(product => product.CategoryId == id);
            return item;
        }

        public Category Add(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public void SaveChanes()
        {
            throw new NotImplementedException();
        }
    }
}
