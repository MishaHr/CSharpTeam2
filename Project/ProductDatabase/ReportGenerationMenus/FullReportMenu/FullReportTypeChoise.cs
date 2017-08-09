using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.ReportGenerationMenus.FullReportMenu;

namespace ProductDatabase.ReportGenerationMenus
{
    static class  FullReportTypeChoice
    {
        internal static void Show()
        {
            Title = "Меню формування повного звіту";
            Clear();
            WriteLine("\tФормування звіту про товар");
            WriteLine("1. Сформувати повний звіт по всіх товарах");
            WriteLine("2. Сформувати повний звіт по вибраній категорії");
            WriteLine();
            WriteLine("\n9. Повернутися до попереднього меню");
            WriteLine("\n0. Повернутися до головного меню");
            Write("\nВиберіть дію: ");
            Choose();

        }

        internal static void Choose()
        {
            string choice = (ReadLine());
            //Clear();
            switch (choice)
            {
                case "0":
                    MainMenu.Show();
                    break;
                case "1":
                    FullReportOutputChoice.Show();


                    break;
                case "2":
                    FullReportByCategory.Show();
                    break;
                case "9":
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
