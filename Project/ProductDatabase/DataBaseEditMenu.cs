using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase
{
    class DataBaseEditMenu
    {
        public static void Show()
        {
            Clear();
            WriteLine("\tРобота з базами");
            WriteLine("\n1. Редагування бази \"Вирбники\"");
            WriteLine("\n2. Редагування бази \"Категорії\"");
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
                    Manufacturer();
                    break;
                case "2":
                    Category();
                    break;
                default:
                    Choose();
                    break;
            }
        }

        public static void Manufacturer()
        {
            WriteLine("\tРедагування бази \"Вирбники\"");
            WriteLine("\n1. Додати нового виробника");
            WriteLine("\n2. Редагувати існуючого виробника");
            WriteLine("\n3. Видалити існуючого виробника");
            WriteLine("\n0. Повернутися до попереднього меню");

            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                case "1":
                    WriteLine("good");
                    break;
                default:
                    Manufacturer();
                    break;
            }
        }

        public static void Category()
        {
            WriteLine("\tРедагування бази \"Категорії\"");
            WriteLine("\n1. Додати нової категорії");
            WriteLine("\n2. Редагувати існуючої категорії");
            WriteLine("\n3. Видалити існуючої категорії");
            WriteLine("\n0. Повернутися до попереднього меню");

            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                case "1":
                    WriteLine("good");
                    break;
                default:
                    Category();
                    break;
            }
        }

        public static void AddNewManufacturer()
        {
            WriteLine("Good");
            AddNewProductMenu.AddProduct();
        }

        public static void AddNewCategory()
        {
            WriteLine("Good");
            AddNewProductMenu.AddProduct();
        }

        public static void Back()
        {
            MainMenu.Show();
        }

    }
}
