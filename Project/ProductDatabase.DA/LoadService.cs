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
                path = @"C:\ProjectDebug\ProjectDB\Products.dat";
            }
            else if (option == "Supplier")
            {
                path = @"C:\ProjectDebug\ProjectDB\Suppliers.dat";
            }
            else if (option == "Category")
            {
                path = @"C:\ProjectDebug\ProjectDB\Category.dat";
            }
            else if (option == "Manufacturer")
            {
                path = @"C:\ProjectDebug\ProjectDB\Manufacturer.dat";
            }
            else if (option == "Memo")
            {
                path = @"C:\ProjectDebug\ProjectDB\Memo.dat";
            }
            else if (option == "WarehouseRecord")
            {
                path = @"C:\ProjectDebug\ProjectDB\WarehouseRecord.dat";
            }
            else if (option == "ShortDescription")
            {
                path = @"C:\ProjectDebug\ProjectDB\ShortDescription.dat";
            }


        }

  
        /// <summary>
        /// метод який добуває всі записи з файлу
        /// </summary>
        /// <returns>повертає List масивів</returns>
        public List<string[]> ReadAll()
        {
            List<string[]> allData = new List<string[]>();
            string line;
            try
            {

                using (StreamReader reader = new StreamReader(path))
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
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException($"Файл {path} відсутній");
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Внутрішня помилка");
            }
            catch (IOException e)
            {
                throw new IOException();
            }
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
