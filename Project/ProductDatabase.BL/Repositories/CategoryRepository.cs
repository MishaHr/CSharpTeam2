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
        private List<Category> _list;

        public CategoryRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator();
            _list = new List<Category>();

            for (int index = 0; index < retrivedData.Count; index++)
            {
                _list.Add(CreateCategory(retrivedData[index]));
            }
        }

        private Category CreateCategory(string[] retrivedData)
        {
            Category category = new Category(Convert.ToInt32(retrivedData[0]));
            category.CategoryName = retrivedData[1].Trim();
            return category;
        }

        /// <summary>
        /// Метод для утворення всього списку категорій
        /// </summary>
        /// <returns>Діст всіх об’єктів Category</returns>
        public IEnumerable<IGetable> GetAll()
      {
          
            return _list;
        }

        /// <summary>
        /// Метод добуває з бази категорію за вказаним ІД
        /// </summary>
        /// <param name="id">ІД категорії, яку треба знайти</param>
        /// <returns>об’єкт типу Category</returns>
        public BaseEntity Get(int id)
        {
            List<Category> categoryList = _list;
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
            _list.Add((Category)objectToAdd);
            SaveTable();
        }

        private void Update(BaseEntity objectToUpdate)
        {

            Category toAdd = objectToUpdate as Category;
            _list.Add(toAdd);
            _list.Remove(toAdd);
            SaveTable();
        }

        private void Delete(BaseEntity objectToDelete)
        {
            Category toDelete = objectToDelete as Category;
            _list.Remove(toDelete);
            SaveTable();
        }

        private void SaveTable()
        {
            List<string> textcategoryList = new List<string>();
            foreach (var category in _list)
            {
                textcategoryList.Add(category.ToString());

            }
            SaveService save = new SaveService();
            save.WrightToFile(textcategoryList);
        }
    }
}
