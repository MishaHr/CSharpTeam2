using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Reposirories
{
    

    /// <summary>
    /// Клас для добування Категорій
    /// </summary>
    public class CategoryRepository
    {
        private string _option  = "Category";
        private List<BaseEntity> _list;

        public CategoryRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator();
            var _list = new List<BaseEntity>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _list.Add(itemCreator.CreateCategory(retrivedData[index]));
            }
        }

      /// <summary>
      /// Метод для утворення всього списку категорій
      /// </summary>
      /// <returns>Діст всіх об’єктів Category</returns>
        public IEnumerable<BaseEntity> GetAll()
        {
            List <BaseEntity> categories = _list;
            return categories;
        }

        /// <summary>
        /// Метод добуває з бази категорію за вказаним ІД
        /// </summary>
        /// <param name="id">ІД категорії, яку треба знайти</param>
        /// <returns>об’єкт типу Category</returns>
        public BaseEntity Get(int id)
        {
            List<Category> categoryList = (List<Category>)_list;
            Category item = _list.FirstOrDefault(product => product.CategoryId == id);
            return item;
        }

        
        

        /// <summary>
        /// Фіксує зміни у записі
        /// </summary>
        public void Save (BaseEntity newData)
        {
            if (newData.IsChanged)
            {
                Update(newData);
            }
            else if (newData.IsNew)
            {
                Add(newData);
            }
            else if (newData.IsDeleted)
            {
                Delete(newData);
            }
        }

        /// <summary>
        /// Метод додає в таблицю новостворений об’єкт Категорії
        /// </summary>
        /// <param name="newObject">Об’єкт нової категорії</param>
        private void Add(BaseEntity objectToAdd)
        {
            _categoryList.Add((Category)objectToAdd);
            SaveTable();
        }

        private void Update(BaseEntity objectToUpdate)
        {
        }

        private void Delete(BaseEntity objectToDelete)
        {
        }

        private void SaveTable()
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
