using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Repositories;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Reposirories
{
    

    /// <summary>
    /// Клас для добування Категорій
    /// </summary>
    internal class CategoryRepository:BaseRepository
    {
        private string _option  = "Category";
        protected internal new List<Category> _list;

        internal CategoryRepository()
        {
            LoadService load = new LoadService(_option);
            List<string[]> retrivedData = load.ReadAll();

            //створюємо і повертаємо об’єкт
           
            _list = new List<Category>();

            foreach (string[] t in retrivedData)
            {
                _list.Add(CreateCategory(t));
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
         internal override IEnumerable<BaseEntity> GetAll()
        {
            return _list;
        }

        /// <summary>
        /// Метод добуває з бази категорію за вказаним ІД
        /// </summary>
        /// <param name="id">ІД категорії, яку треба знайти</param>
        /// <returns>об’єкт типу Category</returns>
        internal override BaseEntity Get(int id)
        {
            List<Category> categoryList = _list;
            Category item = _list.FirstOrDefault(product => product.id == id);
            return item;
        }

        /// <summary>
        /// Фіксує зміни у записі
        /// </summary>
        internal override void Save(BaseEntity newData)
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
        protected internal override void Add(BaseEntity objectToAdd)
        {
            _list.Add((Category)objectToAdd);
            SaveTable();
        }

        protected  internal override void Update(BaseEntity objectToUpdate)
        {

            Category toAdd = objectToUpdate as Category;
            _list.Add(toAdd);
            _list.Remove(toAdd);
            SaveTable();
        }

        protected internal override void Delete(BaseEntity objectToDelete)
        {
            Category toDelete = objectToDelete as Category;
            _list.Remove(toDelete);
            SaveTable();
        }

        protected internal override void SaveTable()
        { 
        List<string> textList = new List<string>();
            foreach (var category in _list)
            {
            textList.Add(category.ToString());
            }
        SaveService save = new SaveService();
        save.WrightToFile(textList);
        }
    }
}
