using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Repos;
using static System.Console;

namespace ProductDatabase
{
    public  class InfoMenu
    {
        public static void Show()
        {
            Console.Write("Введіть ID товару: ");
            Choose();
        }

        private static void Choose()
        {
            
            
            InfoMenu.Back();
        }

        private static void Back()
        {
            WriteLine();
            Write("Натисніть любу клавышу щоб повернутись до попереднього меню.");
            ReadKey();
            MainMenu.Show();
        }
    }
}
