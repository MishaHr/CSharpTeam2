using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Reports;

namespace ProductDatabase
{
    /// <summary>
    /// Тимчасовий клас для тестування звітів
    /// </summary>
    public static class TestReportsMenu
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("1. Згенерувати звіт по вибраный категорії");
            Console.WriteLine("2. Вибрати категорую по Коду");
            Console.WriteLine("3. Переглянути список категорій");
            Console.WriteLine("\n0. До попереднього меню");
            Console.Write("\nВведіть ваш вибір: ");
            Choose();
        }

        private static void Choose()
        {
            
            string choice;
               choice = Console.ReadLine();
            Console.Clear();
            ObjectToStringConverter display = new ObjectToStringConverter();
            switch (choice)
            {

                //Тест побудови звіту
                case "1":
                {
                    var text = display.CategoryListToText();
                    foreach (var s in text)
                    {
                        Console.WriteLine(s);
                    }
                        Console.Write("Виберіть категорію: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    var category = display.CategoryToText(id);
                    Console.WriteLine($"{category}\n");
                        var report = Controller.ShowByCategory(id);
                    foreach (var item in report)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine();
                    }
                        Back();
                        break;
                }

                //тест виводу на екран категорії по ій-ді
                case "2":
                {
                    Console.Write("enter Category ID:");
                    int id = Convert.ToInt32(Console.ReadLine());
                        
                    var text = display.CategoryToText(id);
                    Console.WriteLine(text);
                        Back();
                        break;

                }

                //тест виводу на екран списку категорій
                case "3":
                {
                        
                        var text = display.CategoryListToText();
                        foreach (var s in text)
                        {
                            Console.WriteLine(s);
                        }
                        Back();
                        break;
                }
                case "0":
                {
                        Back();
                        break;
                }
                default:
                    Show();
                    break;
            }
        }

        private static void Back()
        {
            
            Console.Write("\nНатисніть любу клавышу щоб повернутись до попереднього меню.");
            Console.ReadKey();
            TestReportsMenu.Show();
        }


    }
}
