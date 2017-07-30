using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Тестовий клас (для експериментів). Пізніше спробую реалізувати репозиторії за допомогу абстрактного класу (або інтерфейсів)
    /// </summary>
    public abstract class AbstractRepository
    {
        public string Option { get; set; }

        public AbstractRepository(string option)
        {
            Option = option;
        }
        /// <summary>
        ///  Метод для добування о’єкту з бази даних. Приймає ID об’єкту як вхідний параметр
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Повертає об’єкт класу Product з відповідни ID</returns>
        public IRetrivable Retrive(int Id)
        {

            //читаєму інфу з файлу
            LoadService load = new LoadService(Option);
            string[] retrivedData = load.ReadFromFile(Id);

            //створюємо і повертаємо об’єкт
            ObjectCreator itemCreator = new ObjectCreator(Option);
            IRetrivable item = itemCreator.GetInstance(retrivedData);
            return item;
        }


    }
}
