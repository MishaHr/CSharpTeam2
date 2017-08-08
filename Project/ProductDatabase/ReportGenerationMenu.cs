using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase
{
    class ReportGenerationMenu
    {
        public static void Show()
        {
            Title = "Меню формування звітів";
            Clear();
            WriteLine("\tФормування звіту про товар");
            WriteLine("\n1. Сформувати повний звіт");
            WriteLine("\n2. Сформувати короткий звіт");
            WriteLine("\n3. Сформувати звіт по скадах");
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
