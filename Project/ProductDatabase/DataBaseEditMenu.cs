using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase
{
    class DataBaseEditMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базами";
            Clear();
            WriteLine("\tРобота з базами");
            WriteLine("\n1. Редагування бази \"Виробники\"");
            WriteLine("2. Редагування бази \"Категорії\"");
            WriteLine("3. Редагування бази \"Постачальники\"");
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
                    Back();
                    break;
                case "1":
                    ManufacturerMenu.Show();
                    break;
                case "2":
                    CategoryMenu.Show();
                    break;
                case "3":
                    SuppliersMenu.Show();
                    break;
                default:
                    Choose();
                    break;
            }
        }

        public static void Back()
        {
            MainMenu.Show();
        }

    }
}
