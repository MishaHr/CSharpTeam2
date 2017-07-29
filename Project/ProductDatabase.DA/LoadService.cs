using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.DA
{
    /// <summary>
    /// Клас для роботи з базою даних. Виконує функції читання
    /// </summary>
    public  class LoadService
    {
        private  char [] Separator { get; } = {';'};
        string path;

        /// <summary>
        /// Коснтруктор який приймає рядкову змінну і на її основі вибирає необхідний файл, з яким потрібно буде працювати
        /// </summary>
        /// <param name="option">на основі змінної робиться вибір потрібного файлу</param>
        public LoadService(string option)
        {
            if (option == "Product")
            {
                path = @"Products.dat";
            }
            else if (option == "Supplier")
            {
                path = @"Suppliers.dat";
            }
            else if (option == "Category")
            {
                path = @"Category.dat";
            }
            else if (option == "Manufacturer")
            {
                path = @"Manufacturer.dat";
            }

        }

        /// <summary>
        /// метод для зчитування цылого рядка з файлу відповідно до ІД.
        /// </summary>
        /// <param name="itemId">Ідентифікатор рядка, який потрибно знайти і обробити</param>
        /// <returns>Повертає масив стрінгів, в кожному елементі якого знаходяться окремі значення рядка</returns>
        public string [] ReadFromFile(int itemId)
        {
            string line;
            int lineId;
            StreamReader reader =
                new StreamReader(path);
            using (reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    string[] retrivedData = ParseToStringArray(line);
                    lineId = Convert.ToInt32(retrivedData[0]);
                    if (lineId == itemId)
                    {
                        return retrivedData;
                    }
                    else
                    {
                        line = reader.ReadLine();
                    }
                }
                
            }

        return null;
        }

        /// <summary>
        /// метод який добуває всі записи з файлу
        /// </summary>
        /// <returns>повертає List масивів</returns>
        public List<string[]> ReadAll()
        {
            List<string[]> allData = new List<string[]>();
            string line;
            StreamReader reader =
                new StreamReader(path);
            using (reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    allData.Add(ParseToStringArray(line));
                    line = reader.ReadLine();
                }
            }
            return allData;
        }

        /// <summary>
        /// Метод для перетворення зчитаного рядка в масив стрінгів
        /// </summary>
        /// <param name="lineFromFile">Рядок, який зчитали з файлу</param>
        /// <returns>Масив стрінгів</returns>
        private string[] ParseToStringArray(string lineFromFile)
        {
            //розбиваємо рядок по коремих комірках. Обірзаємо лишні пробіли
            string [] parsedData = lineFromFile.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            return parsedData;
        }
    }
}
