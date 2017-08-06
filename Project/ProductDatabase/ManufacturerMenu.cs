using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase
{
    class ManufacturerMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базою \"Виробники\"";
            Clear();
            WriteLine("\tРедагування бази \"Виробники\"");
            WriteLine("\n1. Додати нового виробника");
            WriteLine("2. Редагувати існуючого виробника");
            WriteLine("3. Видалити існуючого виробника");
            WriteLine("\n9. Повернутися до головного меню");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВиберіть дію яку ви хочете виконати: ");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    DataBaseEditMenu.Show();
                    break;
                case "1":
                    AddManufacturer();
                    break;
                case "2":
                    EditManufacturer();
                    break;
                case "3":
                    DeleteManufacturer();
                    break;
                case "9":
                    MainMenu.Show();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private static void AddManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть назву виробника : ");
            string ManufacturerName = (ReadLine());
            Clear();
            WriteLine("Назва виробника : {0}", ManufacturerName);
            WriteLine("\nВиробника введено успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
            ReadLine();
            Show();
        }

        private static void EditManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть ID виробника : ");
            int ManufacturerID = Convert.ToInt32(Console.ReadLine());
            string ManufacturerName = display.ManufacturerToText(ManufacturerID);
            Clear();
            WriteLine("Виробник : {0}", ManufacturerName);
            WriteLine("\nВведіть нову назву виробника : ");
            ManufacturerName = (ReadLine());
            WriteLine("\nНазву виробника змінено : {0}", ManufacturerName);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }

        private static void DeleteManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть ID виробника : ");
            int ManufacturerID = Convert.ToInt32(Console.ReadLine());
            string ManufacturerName = display.ManufacturerToText(ManufacturerID);
            Clear();
            WriteLine("Виробника {0} видалено успішно!", ManufacturerName);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }
    }
}
