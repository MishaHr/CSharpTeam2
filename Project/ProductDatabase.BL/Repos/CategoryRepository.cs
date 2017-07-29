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
    public class CategoryRepository
    {
        //змінна вибору відповідного файлу бази даних (пізніше перероблю механізм)
        public string Option { get; private set; } = "Category";

        /// <summary>
        /// Метод для добування о’єкту Категорії з бази даних. Приймає ID категорії як вхідний параметр
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Повертає об’єкт класу Category з відповідни ID</returns>
        public Category Retrive(int id)
        {

            //читаєму інфу з файлу
            LoadService load = new LoadService(Option);
            string[] retrivedData = load.ReadFromFile(id);


            //заповнюємо відповідні поля в об’єкту Category (це можна винести в майбутньому в окремий клас-Фабрику)
            Category item = new Category(Convert.ToInt32(retrivedData[0]));
            item.CategoryName = retrivedData[1];

            return item;
        }
    }
}
