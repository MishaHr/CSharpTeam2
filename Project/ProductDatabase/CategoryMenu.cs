using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.CustomExceptions;

namespace ProductDatabase
{
    class CategoryMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базою \"Категорії\"";
            Clear();
            WriteLine("\tРедагування бази \"Категорії\"");
            WriteLine("\n1. Додати нової категорії");
            WriteLine("2. Редагувати існуючої категорії");
            WriteLine("3. Видалити існуючої категорії");
            WriteLine("\n9. Повернутися до головного меню");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВиберіть дію яку ви хочете виконати: ");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    DataBaseEditMenu.Show();
                    break;
                case "1":
                    AddCategory();
                    break;
                case "2":
                    EditCategory();
                    break;
                case "3":
                    DeleteCategory();
                    break;
                case "9":
                    MainMenu.Show();
                    break;
                default:
                    Show();
                    break;
            }
        }

        public static void AddCategory()
        {
            /*змінна що вказую правельність проходження меню 
            (якщо вибивають помилки чек вертає для повторного проходження)*/
            bool check = false;

            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            try
            {
                var category = display.CategoryListToText();
                foreach (var cat in category)
                {
                    Console.WriteLine(cat);
                }
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine(ne.Message);
                
            }
            Write("\nВведіть назву категорії : ");
            do
            {
                try
                {
                    check = false;
                    string newCategoryName = (ReadLine());
                    Validation.CategoryName(newCategoryName);
                    string[] toAdd = {newCategoryName};
                    CategoryEditor edit = new CategoryEditor();
                    edit.Add(toAdd);
                    Clear();
                    check = true;
                    WriteLine("Назва категорії : {0}", newCategoryName);
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
            }
            while (!check);
            WriteLine("\nКатегорія введена успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
            ReadLine();
            Show();
        }

        private static void EditCategory()
        {
            //змінна що вказую правельність проходження меню 
            bool check = false;

            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
                try
                {
                    var category = display.CategoryListToText();
                    foreach (var cat in category)
                    {
                        Console.WriteLine(cat);
                    }
                }
            catch (NullReferenceException e)
            {
                WriteLine(e.Message);
            }
            do
            {
                try
                {
                    check = false;
                    Write("\nВведіть ID категорії : ");
                    string CategoryID = Console.ReadLine();
                    Validation.Id(CategoryID);
                    Write("\nВведіть нову назву категорії : ");
                    string newCategoryName = (ReadLine());
                    Validation.CategoryName(newCategoryName);
                    string[] edited = {CategoryID, newCategoryName};
                    CategoryEditor edit = new CategoryEditor();
                    edit.Edit(edited);
                    check = true;
                    WriteLine("\nНазву категорії змінено : {0}", newCategoryName);
                    WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
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
            } while (!check);
            ReadLine();
            Show();
        }

        private static void DeleteCategory()
        {
            //змінна що вказую правельність проходження меню 
            bool check = false;

            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            try
            {
                var category = display.CategoryListToText();
                foreach (var cat in category)
                {
                    Console.WriteLine(cat);
                }
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine(ne.Message);
            }
            do
            {
                try
                {
                    check = false;
                    Write("\nВведіть ID категорії : ");
                    string categoryID = Console.ReadLine();
                    Validation.Id(categoryID);
                    CategoryEditor edit = new CategoryEditor();
                    edit.Delete(Convert.ToInt32(categoryID));
                    Clear();
                    WriteLine("Категорію видалено успішно!");
                    WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
                    ReadLine();
                    Show();
                    check = true;
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
            } while (!check);
        }
    }
}
