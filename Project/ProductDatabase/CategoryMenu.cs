using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase
{
    class CategoryMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базою \"Категорії\"";
            Clear();
            WriteLine("\tРедагування бази \"Категорії\"");
            WriteLine("\n1. Додати нової категорії");
            WriteLine("2. Редагувати існуючої категорії");
            WriteLine("3. Видалити існуючої категорії");
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
                    AddCategory();
                    break;
                case "2":
                    EditCategory();
                    break;
                case "3":
                    DeleteCategory();
                    break;
                case "9":
                    DataBaseEditMenu.Show();
                    break;
                default:
                    Show();
                    break;
            }
        }

        public static void AddCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть назву категорії : ");
            string CategoryName = (ReadLine());
            Clear();
            WriteLine("Назва категорії : {0}", CategoryName);
            WriteLine("\nКатегорія введена успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }

        private static void EditCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            string CategoryName = display.CategoryToText(CategoryID);
            Clear();
            WriteLine("Категорія : {0}", CategoryName);
            WriteLine("\nВведіть нову назву категорії : ");
            CategoryName = (ReadLine());
            WriteLine("\nНазву категорії змінено : {0}", CategoryName);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }

        private static void DeleteCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            string CategoryName = display.CategoryToText(CategoryID);
            Clear();
            WriteLine("Категорію {0} видалено успішно!", CategoryName);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }
    }
}
