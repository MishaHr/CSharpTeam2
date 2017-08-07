using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using ProductDatabase.BL;
using ProductDatabase.BL.Editors;
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
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Delete");
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
            ManufacturerEditor manEd = new ManufacturerEditor();
            string newName = "NewMan";
            switch (choice)
            {
                
                //Тест побудови звіту
                case "1":
                {
                    
                    manEd.Add(newName);
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
                        manEd.Edit(id, newName);
                        
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
                    Console.Write("enter ID:");
                    int id = Convert.ToInt32(Console.ReadLine());
                        manEd.Delete(id);
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
