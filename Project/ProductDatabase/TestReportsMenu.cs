using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
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
            Console.WriteLine("2. Вибрати по Коду");
            Console.WriteLine("3. Переглянути список");
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
                    try
                    {
                        var text = display.CategoryListToText();
                        foreach (var s in text)
                        {
                            Console.WriteLine(s);
                        }

                        Console.Write("Виберіть: ");

                        string textid = Console.ReadLine();
                        bool valid = true;
                        Console.Clear();
                        if (valid == true)
                        {
                            int id = Convert.ToInt32(textid);

                            var category = display.CategoryToText(id);
                            Console.WriteLine($"{category}\n");
                            var report = TextReportShower.ShowWarehouseReportByCategory(id);
                            foreach (var item in report)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not valid");
                        }


                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                    
                    
                        Back();
                        break;
                }

                //тест виводу на екран категорії по ій-ді
                case "2":
                {
                    try
                    {
                        Console.Write("enter ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bool check = true;//Validation.Id(id);
                        if (check==true)
                        {
                            var text = display.ManufacturerToText(id);
                            Console.WriteLine(text);
                        }
                        
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    catch (FileNotFoundException fnfe)
                    {
                            Console.WriteLine(fnfe.Message);
                    }

                    Back();
                        break;

                }

                //тест виводу на екран списку категорій
                case "3":
                {

                    var text = TextReportShower.ShowFullProductReport();
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
