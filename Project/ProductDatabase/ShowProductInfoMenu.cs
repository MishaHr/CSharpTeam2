using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase
{
    class ShowProductInfoMenu
    {
        public static void Show()
        {
            Clear();
            WriteLine("\tПерегляд інформації про товар");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВведіть ID товару: ");
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
                    ShowInfo();
                    break;
            }
        }

        public static void ShowInfo()
        {
            //Clear();
            string choice = (ReadLine());
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                default:
                    // метод для перевірки коректності введеного значення та подальшого виведення інформації на екран
                    ShowInfo();
                    break;
            }
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
