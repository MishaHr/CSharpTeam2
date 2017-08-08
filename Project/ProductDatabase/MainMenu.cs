using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Entities;


namespace ProductDatabase
{
    /// <summary>
    /// Клас головного меню програми
    /// </summary>
    public static class MainMenu
    {

        /// <summary>
        /// Метод виводу пунктыв меню на екран
        /// </summary>
        public static void Show()
        {
            Title = "\tГоловне меню програми";
            Clear();
            WriteLine("\tГоловне меню:");
            WriteLine("\n1. Додати новий товар");
            WriteLine("2. Переглянути інформацію про товар");
            WriteLine("3. Редагувати інформацію про товар");
            WriteLine("4. Видалити існуючий товар");
            WriteLine("5. Згенерувати звіт");
            WriteLine("6. Робота з базами");
            WriteLine("\n0. Вихід з програми");
            Write("\nВиберіть дію яку ви хочете виконати: ");
            Choose();
        }

        /// <summary>
        /// Метод обробки введенного користувачем з клавыатури вибору пункту меню
        /// </summary>
        private static void Choose()
        {
            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "1":
                    AddNewProductMenu.AddProduct();
                    break;
                case "2":
                    ShowProductInfoMenu.Show();
                    break;
                case "3":
                    EditProductMenu.EditProduct();
                    break;
                case "4":
                    DeleteProductMenu.Show();
                    break;
                case "5":
                    ReportGenerationMenu.Show();
                    break;
                case "6":
                    DataBaseEditMenu.Show();
                    break;
                case "0":
                    Back();
                    break;
                default:
                    WriteLine("Ви ввели помилковий символ, натисніть будь яку клавішу для продовження!");
                    //ReadKey();
                    Show();
                    break;
            }
        }

        /// <summary>
        /// Метод для повернення до попереднього пункту меню
        /// </summary>
        private static void Back()
        {

        }
    }
}
