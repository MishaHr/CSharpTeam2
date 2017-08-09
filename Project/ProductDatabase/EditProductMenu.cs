using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using System.IO;


namespace ProductDatabase
{
    class EditProductMenu
    {
        public static void Show()
        {
            Title = "Меню редагування товару";
            Clear();
            WriteLine("\tРедагування товару");
            WriteLine("\n1. Редагувати основні дані");
            WriteLine("2. Редагувати Короткий опис");
            WriteLine("3. Редагувати Примітку");
            WriteLine("4. Редагувати запис на склад");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nОберіть пункт: ");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            //Clear();
            switch (choice)
            {
                case "0":
                    MainMenu.Show();
                    break;
                case "1":
                    
                    Back();
                    break;
                case "2":
                    
                    Back();
                    break;
                case "3":
                    
                    Back();
                    break;
                default:
                    Show();
                    break;
            }
        }

        public static void ReportGeneration()
        {

        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
