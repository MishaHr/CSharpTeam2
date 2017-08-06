using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

namespace ProductDatabase
{
    class DataBaseEditMenu
    {
        public static void Show()
        {
            Clear();
            WriteLine("\tРобота з базами");
            WriteLine("\n1. Редагування бази \"Виробники\"");
            WriteLine("2. Редагування бази \"Категорії\"");
            WriteLine("3. Редагування бази \"Постачальники\"");
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
                    Back();
                    break;
                case "1":
                    Manufacturer();
                    break;
                case "2":
                    Category();
                    break;
                case "3":
                    Suppliers();
                    break;
                default:
                    Choose();
                    break;
            }
        }

        public static void Manufacturer()
        {
            Clear();
            WriteLine("\tРедагування бази \"Виробники\"");
            WriteLine("\n1. Додати нового виробника");
            WriteLine("2. Редагувати існуючого виробника");
            WriteLine("3. Видалити існуючого виробника");
            WriteLine("\n9. Повернутися до головного меню");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВиберіть дію яку ви хочете виконати: ");

            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    Show();
                    break;
                case "1":
                    AddManufacturer();
                    break;
                case "2":
                    EditManufacturer();
                    break;
                case "3":
                    DeleteManufacturer();
                    break;
                case "9":
                    MainMenu.Show();
                    break;
                default:
                    Manufacturer();
                    break;
            }
        }

        private static void AddManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть назву виробника : ");
            string ManufacturerName = (ReadLine());
            Clear();
            WriteLine("Назва виробника : {0}", ManufacturerName);
            WriteLine("\nВиробника введено успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
            ReadLine();
            DataBaseEditMenu.Manufacturer();
        }

        private static void EditManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть ID виробника : ");
            int ManufacturerID = Convert.ToInt32(Console.ReadLine());
            string ManufacturerName = display.ManufacturerToText(ManufacturerID);
            Clear();
            WriteLine("Виробник : {0}", ManufacturerName);
            WriteLine("\nВведіть нову назву виробника : ");
            ManufacturerName = (ReadLine());
            WriteLine("\nНазву виробника змінено : {0}", ManufacturerName);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            DataBaseEditMenu.Manufacturer();
        }

        private static void DeleteManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть ID виробника : ");
            int ManufacturerID = Convert.ToInt32(Console.ReadLine());
            string ManufacturerName = display.ManufacturerToText(ManufacturerID);
            Clear();
            WriteLine("Виробника {0} видалено успішно!", ManufacturerName);
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            DataBaseEditMenu.Manufacturer();
        }

        public static void Category()
        {
            Clear();
            WriteLine("\tРедагування бази \"Категорії\"");
            WriteLine("\n1. Додати нової категорії");
            WriteLine("2. Редагувати існуючої категорії");
            WriteLine("3. Видалити існуючої категорії");
            WriteLine("\n9. Повернутися до головного меню");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВиберіть дію яку ви хочете виконати: ");

            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    Show();
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
                    Category();
                    break;
            }
        }

        public static void AddCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть назву категорії : ");
            string newCategoryName = (ReadLine());
            CategoryEditor.Add(newCategoryName);
            //Clear();
            //WriteLine("Назва категорії : {0}", newCategoryName);
            //WriteLine("\nКатегорія введена успішно!");
            //WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            //ReadLine();
            //DataBaseEditMenu.Category();
        }

        private static void EditCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            string CategoryName = display.CategoryToText(CategoryID);
            Clear();
            WriteLine("Категорія : {0}", CategoryName);
            WriteLine("\nВведіть нову назву категорії : ");
            CategoryName = (ReadLine());
            CategoryEditor.Edit(CategoryID, CategoryName);
            //WriteLine("\nНазву категорії змінено : {0}", CategoryName);
            //WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            //ReadLine();
            //DataBaseEditMenu.Category();
        }

        private static void DeleteCategory()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих категорій\n");
            var category = display.CategoryListToText();
            foreach (var cat in category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            CategoryEditor.Delete(CategoryID);
            //string CategoryName = display.CategoryToText(CategoryID);
            //Clear();
            //WriteLine("Категорію {0} видалено успішно!", CategoryName);
            //WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            //ReadLine();
            //DataBaseEditMenu.Category();
        }

        public static void Suppliers()
        {
            Clear();
            WriteLine("\tРедагування бази \"Постачальники\"");
            WriteLine("\n1. Додати нового постачальника");
            WriteLine("2. Редагувати існуючого постачальника");
            WriteLine("3. Видалити існуючого постачальника");
            WriteLine("\n9. Повернутися до головного меню");
            WriteLine("\n0. Повернутися до попереднього меню");
            Write("\nВиберіть дію яку ви хочете виконати: ");

            string choice = (ReadLine());
            Clear();
            switch (choice)
            {
                case "0":
                    Show();
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
                    Suppliers();
                    break;
            }
        }

        private static void AddSuppliers()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToTextShort();
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
            DataBaseEditMenu.Suppliers();
        }

        private static void EditSuppliers()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToTextFull();
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
            DataBaseEditMenu.Suppliers();
        }

        private static void DeleteSuppliers()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToTextFull();
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
            DataBaseEditMenu.Suppliers();
        }

        public static void Back()
        {
            MainMenu.Show();
        }

    }
}
