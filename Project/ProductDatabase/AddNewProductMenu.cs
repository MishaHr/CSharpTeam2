using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase
{
    class AddNewProductMenu
    {
        public static void Show()
        {
            Clear();
            WriteLine("\tДодавання товару");
            WriteLine("\n1. Додати товар");
            WriteLine("\n0. Повернутися до попереднього меню");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                case "1":
                    AddProduct();
                    break;
                default:
                    Choose();
                    break;
            }
        }

        //public static void AddProduct()
        //{
        //    //Clear();
        //    Write("Введіть назву товару : ");
        //    string ProductName = (ReadLine());
        //    int Row = CursorTop;
        //    SetCursorPosition(0, Row-1);
        //    Write("Назва товару : {0}", ProductName.PadRight(100));
        //    WriteLine("Введіть назву товару : ");
        //    string ProductManufacturer = (ReadLine());
        //    WriteLine(ProductManufacturer);
        //    Back();
        //}

        public static void AddProduct()
        {
            WriteLine("Список категорій");
            WriteLine("0. Додати нову категорію");
            Write("\nВведіть ID категорії зі списка або додайе нову : ");
            string ProductCategory = (ReadLine());
            if (ProductCategory == "0")
            {
                DataBaseEditMenu.AddNewCategory();
            }
            else
            {
                Clear();
                WriteLine("Категорія : {0}", ProductCategory); // замсть ID має підібратися назва категорії
            }
            Write("\nВиберіть виробника : ");
            string ProductManufacturer = (ReadLine());
            if (ProductManufacturer == "0")
            {
                DataBaseEditMenu.AddNewManufacturer();
            }
            else
            {
                Clear();
                WriteLine("Категорія : {0}", ProductCategory);
                WriteLine("Виробник : {0}", ProductManufacturer);
            }
            Write("\nВведіть назву товару : ");
            string ProductName = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            ReadLine();
            Back();
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
