using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.CustomExceptions;

namespace ProductDatabase.ReportGenerationMenus.ShortReportMenu
{
    internal static  class ShortReportOutputChoice
    {
        internal static void Show()
        {
            Title = "Меню формування короткого звіту";
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
                    var report = TextReportShower.ShowShortProductReport();
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
                    Clear();
                    TextReportSave fullReport = new TextReportSave();
                    fullReport.SafeShortProductReport();
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
            ShortReportTypeChoice.Show();
        }
    }
}
