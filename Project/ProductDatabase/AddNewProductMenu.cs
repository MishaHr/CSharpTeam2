using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase
{
    class AddNewProductMenu
    {
        public static void Show()
        {
            Clear();
            WriteLine("\tДодавання товару");
            WriteLine("\n0. Повернутися до попереднього меню");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            //Clear();
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                default:
                    AddProduct();
                    break;
            }
        }

        public static void AddProduct()
        {
            //Clear();
            string choice = (ReadLine());
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                default:
                    // метод для перевірки коректності введеного значення та подальшого введення інформації про новий товар
                    AddProduct();
                    break;
            }
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
