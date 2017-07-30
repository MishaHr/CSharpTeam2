using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Repos;

namespace ProductDatabase
{
    /// <summary>
    /// Клас головного меню програми
    /// </summary>
    public static  class MainMenu
    {

        /// <summary>
        /// Метод виводу пунктыв меню на екран
        /// </summary>
        public  static void Show()
        {
            Clear();
            WriteLine("Головне меню:");
            WriteLine("1. Показати інфо про товар");
            WriteLine("2. Додати товар");
            WriteLine("0. Вихід з програми");
            Write("\nВиберіть дію: ");
            Choose();
        }

        /// <summary>
        /// Метод обробки введенного користувачем з клавыатури вибору пункту меню
        /// </summary>
        private static void Choose()
        {
            
            int choice = Convert.ToInt32(ReadLine());
            Clear();
            if (choice == 1)
            {
               InfoMenu.Show();
            }
            else if (choice == 2)
            {
                UnderConstructionMenu.Show();
            }
            else if (choice == 0)
            {
                Back();
            }
        }

        /// <summary>
        /// Метод для повернення до попереднього пункту меню
        /// </summary>
        private static void Back()
        {
            
        }
    }
}
