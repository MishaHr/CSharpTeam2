using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.ReportGenerationMenus
{
    internal static class ReportOutputChoice
    {
        internal static void Show()
        {
            Title = "Меню формування повного звіту";
            Clear();
            WriteLine("\tФормування звіту про товар");
            WriteLine("\n1. Сформувати повний звіт по всіх товарах");
            WriteLine("\n2. Сформувати повний звіт по вибраній категорії");
            WriteLine();
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВведіть ID товару: ");
            Choose();

        }

        internal static void Choose()
        {
            string choice = (ReadLine());
            //Clear();
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                case "1":



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

        internal static void Back()
        {
            ReportGenerationMenu.Show();
        }
    }
}
