using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.CustomExceptions;

namespace ProductDatabase.ReportGenerationMenus.WarehouseReportMenu
{
    internal static class WarehouseReportBycategory
    {
        private static bool _check = false;
        private static int _id;

        internal static void Show()
        {
            Title = "Меню формування звіту по складу по категоріям";
            Clear();
            WriteLine("\tФормування звіту про товар по категоріям");
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
                    Clear();
                    WriteLine("\tФормування звіту по складу по категоріям");
                    ShowAllCategories();
                    do
                    {
                        try
                        {
                            Console.Write("Виберіть категорію: ");
                            string categoryId = ReadLine();
                            Validation.Id(categoryId);
                            _id = Convert.ToInt32(categoryId);

                            Clear();
                            WriteLine("\tПовний звіт про товар по категорії");
                            var report = TextReportShower.ShowWarehouseReportByCategory(_id);
                            foreach (var r in report)
                            {
                                Console.WriteLine(r);
                                Console.WriteLine();
                            }
                            _check = true;
                        }
                        catch (CustomeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (FileNotFoundException fnfe)
                        {
                            Console.WriteLine(fnfe.Message);
                        }
                        catch (IOException ie)
                        {
                            Console.WriteLine(ie.Message);
                        }

                    } while (!_check);

                    Console.WriteLine("Натисніть любу клавішу щоб повернутись до попереднього меню");
                    ReadKey();
                    Back();

                    break;
                case "2":
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
           WarehouseReportTypeChoice.Show();
        }

        private static void ShowAllCategories()
        {
            try
            {
                ObjectToStringConverter strings = new ObjectToStringConverter();
                var categories = strings.CategoryListToText();
                foreach (string category in categories)
                {
                    Console.WriteLine(category);
                }
            }
            catch (NullReferenceException e)
            {
                WriteLine(e);
            }

        }
    }
}
