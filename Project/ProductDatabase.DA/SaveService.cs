using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProductDatabase.DA
{
    /// <summary>
    /// Клас для запису інформації у файл.
    /// </summary>
    public static class SaveService
    {
        static string path, oldPath;
        /// <summary>
        /// Коснтруктор який приймає рядкову змінну і на її основі вибирає необхідний файл, з яким потрібно буде працювати
        /// Конструкто також приймає Ліст стрінгів, який треба записати в файл
        /// </summary>
        /// <param name="option"></param>
        /// <param name="list"></param>
        public static void SaveToFile(string option, List<string> list)
        {
            switch (option)
            {
                case "Product":
                oldPath = @"Products_old.dat";
                path = @"Products.dat";
                break;
                case "Supplier":
                oldPath = @"Suppliers_old.dat";
                path = @"Suppliers.dat";
                break;
                case "Category":
                oldPath = @"Category_old.dat";
                path = @"Category.dat";
                break;
                case "Manufacturer":
                oldPath = @"Manufacturer_old.dat";
                path = @"Manufacturer.dat";
                break;
                case "Memo":
                oldPath = @"Memo_old.dat";
                path = @"Memo.dat";
                break;
                case "WarehouseRecord":
                oldPath = @"WarehouseRecord_old.dat";
                path = @"WarehouseRecord.dat";
                break;
                case "ShortDescription":
                oldPath = @"ShortDescription_old.dat";
                path = @"ShortDescription.dat";
                break;
                case "LastIdKeeper":
                oldPath = @"LastIdKeeper_old.dat";
                path = @"LastIdKeeper.dat";
                break;
            }
            //видаляєм резервний файл
            File.Delete(oldPath);
            //перезаписує поточний файл в резервний
            File.Move(path, oldPath);
            //створюємо новий файл з обновленими даними
            FileInfo file = new FileInfo(path);
            FileStream stream = file.Open(FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (var text in list)
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}

