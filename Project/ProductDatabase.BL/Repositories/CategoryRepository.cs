using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Reposirories
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
            ObjectCreator itemCreator = new ObjectCreator();
            _categoryList = new List<Category>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _categoryList.Add(itemCreator.CreateCategory(retrivedData[index]));
            }
        }

      /// <summary>
      /// Метод для утворення всього списку категорій
      /// </summary>
      /// <returns>Діст всіх об’єктів Category</returns>
        public IEnumerable<IGetable> GetAll()
        {
            List <Category> categories = _categoryList;
            return categories;
        }

        /// <summary>
        /// Метод добуває з бази категорію за вказаним ІД
        /// </summary>
        /// <param name="id">ІД категорії, яку треба знайти</param>
        /// <returns>об’єкт типу Category</returns>
        public IGetable Get(int id)
        {
            Category item = _categoryList.FirstOrDefault(product => product.CategoryId == id);
            return item;
        }

        /// <summary>
        /// Метод додає в таблицю новостворений об’єкт Категорії
        /// </summary>
        /// <param name="newObject">Об’єкт нової категорії</param>
        public void Add(IGetable newObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод зберігає всю таблицю категорій у файл
        /// </summary>
        public void SaveChanges()
        {
            List<string> textcategoryList = new List<string>();
            foreach (var category in _categoryList)
            {
                textcategoryList.Add(category.ToString());

            }
            SaveService save = new SaveService();
            save.WrightToFile(textcategoryList);
        }
    }
}
