using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Main_Classes
{
    /// <summary>
    /// Клас для добування Виробників
    /// </summary>
    public class ManufacturerRepository
    {
        //змінна вибору відповідного файлу бази даних (пізніше перероблю механізм)
        public string Option { get; set; } = "Manufacturer";

        /// <summary>
        /// Метод для добування о’єкту Виробника з бази даних. Приймає ID виробника як вхідний параметр
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Повертає об’єкт класу Manufacturer з відповідним ID</returns>
        public Manufacturer Retrive(int id)
        {

            //читаєму інфу з файлу
            LoadService load = new LoadService(Option);
            string[] retrivedData = load.ReadFromFile(id);


            //заповнюємо відповідні поля в об’єкту Manufacturer (це можна винести в майбутньому в окремий клас-Фабрику)
            Manufacturer item = new Manufacturer(Convert.ToInt32(retrivedData[0]));
            item.ManufacturerName = retrivedData[1];

            return item;
        }
    }
}
