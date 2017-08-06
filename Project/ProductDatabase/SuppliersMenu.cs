using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase
{
    class SuppliersMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базою \"Постачальники\"";
            Clear();
            WriteLine("\tРедагування бази \"Постачальники\"");
            WriteLine("\n1. Додати нового постачальника");
            WriteLine("2. Редагувати існуючого постачальника");
            WriteLine("3. Видалити існуючого постачальника");
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
                    AddSuppliers();
                    break;
                case "2":
                    EditSuppliers();
                    break;
                case "3":
                    DeleteSuppliers();
                    break;
                case "9":
                    MainMenu.Show();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private static void AddSuppliers()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToText();
            foreach (var sup in suppliers)
            {
                Console.WriteLine(sup);
            }
            Write("\nВведіть назву постачальника : ");
            string SupplierName = (ReadLine());
            Clear();
            WriteLine("Назва постачальника : {0}", SupplierName);
            Write("\nВведіть номер телефону постачальника : +38(000)000-00-00"); // формат введення при потреба змінити
            AddNewProductMenu.WriteAt(39, 2);
            string SupplierPhoneNumber = (ReadLine());
            Clear();
            WriteLine("Назва постачальника : {0}", SupplierName);
            WriteLine("Номер телефону постачальника : {0}", SupplierPhoneNumber);
            WriteLine("\nПостачальника введено успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
            ReadLine();
            Show();
        }

        private static void EditSuppliers()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToText();
            foreach (var sup in suppliers)
            {
                Console.WriteLine(sup);
            }
            Write("\nВведіть ID постачальника : ");
            int SupplierId = Convert.ToInt32(Console.ReadLine());
            string SupplierInfo = display.SupplierToText(SupplierId);
            Clear();
            WriteLine("Постачальник : {0}", SupplierInfo);
            Write("\nВведіть нову назву постачальника : ");
            string SupplierName = (ReadLine());
            Write("\nВведіть номер телефону постачальника : +38(000)000-00-00"); // формат введення при потреба змінити
            AddNewProductMenu.WriteAt(39, 4);
            string SupplierPhoneNumber = (ReadLine());
            WriteLine("\nДані постачальника змінено : {0}, тел:{1}", SupplierName, SupplierPhoneNumber);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }

        private static void DeleteSuppliers()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToText();
            foreach (var sup in suppliers)
            {
                Console.WriteLine(sup);
            }
            Write("\nВведіть ID постачальника : ");
            int SupplierId = Convert.ToInt32(Console.ReadLine());
            string SupplierInfo = display.SupplierToText(SupplierId);
            Clear();
            WriteLine("Постачальника {0} видалено успішно!", SupplierInfo);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Show();
        }
    }
}
