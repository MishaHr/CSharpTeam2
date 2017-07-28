using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProductDatabase
{
    public static  class UnderConstructionMenu
    {
        public static void Show()
        {
            WriteLine("This menu is under construction");
            WriteLine("Press any key to return to main menu...");
            ReadKey();
            Back();
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
