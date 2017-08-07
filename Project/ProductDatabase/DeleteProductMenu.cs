using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase
{
    class DeleteProductMenu
    {
        public static void Show()
        {
            Clear();
            WriteLine("\tРедагування товару");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВведіть ID товару: ");
            Choose();
        }

        public static void Choose()
        {
            string choice = (ReadLine());
            //Clear();
            switch (choice)
            {
                case "0":
                    Back();
                    break;
                default:
                    DeleteProduct();
                    break;
            }
        }

        public static void DeleteProduct()
        {
            Title = "\tМеню видалення існуючого товару";



            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");

            ReadLine();
            Back();
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
