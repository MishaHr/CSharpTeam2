using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase.ReportGenerationMenus.FullReportMenu
{
    internal static class FullReportOutputChoice
    {
        internal static void Show()
        {
            Title = "Меню формування повного звіту";
            Clear();
            WriteLine("\tФормування звіту про товар");
            WriteLine("1. Вивести на екран");
            WriteLine("2. Зберегти у файл");
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
                    var report = TextReportShower.ShowFullProductReport();
                    foreach (var r in report)
                    {
                        Console.WriteLine(r);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Натисніть любу клавішу щоб повернутись до попереднього меню");
                    ReadKey();
                    Back();
                    break;
                case "2":
                    TextReportSave fullReport = new TextReportSave();
                    fullReport.SafeFullProductReport();
                    Console.WriteLine("Звіт про товар збережено.");
                    Console.WriteLine("Натисніть любу клавішу щоб повернутись до попереднього меню");
                    ReadKey();
                    Back();
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
           FullReportTypeChoice.Show();
        }
    }
}
