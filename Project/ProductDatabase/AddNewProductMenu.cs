using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;

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
                    AddProduct();
                    break;
            }
        }

        public static void WriteAt(int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void AddProduct()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            //WriteLine("0. Повернутися до попереднього меню");
            WriteLine("Список категорій\n");
            var Category = display.CategoryListToText();
            foreach (var cat in Category)
            {
                Console.WriteLine(cat);
            }
            Write("\nВведіть ID категорії зі списку : ");
            int CategoryID = Convert.ToInt32(Console.ReadLine());
            string ProductCategory = display.CategoryToText(CategoryID);
            //if (ProductCategory == "0")
            //{
            //    Back();
            //}
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);

            WriteLine("\nСписок виробників\n");
            var Manufacturer = display.ManufacturerListToText();
            foreach (var man in Manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть ID виробника зі списку : ");
            int ManufacturerID = Convert.ToInt32(Console.ReadLine());
            string ProductManufacturer = display.ManufacturerToText(ManufacturerID);
            //string ProductManufacturer = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);

            Write("\nВведіть назву товару : ");
            string ProductName = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);

            Write("\nВведіть дату виготовлення : 00.00.0000"); // потрібно буде привести приклад правильного формату
            WriteAt(28, 4);
            string ProductManufactureDate = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);

            Write("\nВведіть гарантійний термін : "); 
            string ProductWarranty = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0} років", ProductWarranty);

            WriteLine("\nСписок постачальників\n"); // будуть відображатись доступні виробники товару для вибору
            var Suppliers = display.SuppliersListToText();
            foreach (var sup in Suppliers)
            {
                Console.WriteLine(sup);
            }
            Write("\nВведіть ID постачальника зі списку : "); // потрібно буде привести приклад правильного формату
            int SupplierId = Convert.ToInt32(Console.ReadLine());
            string ProductProvider = display.SupplierToText(SupplierId);
            //string ProductProvider = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);

            Write("\nВведіть дату поставки : 00.00.0000");
            WriteAt(24, 7);
            string ProductDeliveryDate = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);

            Write("\nВведіть кількість одиниць : ");
            string ProductAmount = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
            WriteLine("Кількість одиниць : {0}", ProductAmount);

            Write("\nВведіть ціну за одиницю : ");
            string ProductPrice = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);

            Write("\nВведіть номер складу : ");
            string ProductWarehouse = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Номер складу : {0}", ProductWarehouse);

            Write("\nВведіть короткий опис : ");
            string ProductDescription = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Номер складу : {0}", ProductWarehouse);
            WriteLine("Короткий опис : {0}", ProductDescription);

            Write("\nЗаповніть поле для приміток якщо потрібно : ");
            string ProductNotes = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Номер складу : {0}", ProductWarehouse);
            WriteLine("Короткий опис : {0}", ProductDescription);
            WriteLine("Примітка : {0}", ProductNotes);

            WriteLine("\nІнформація введена успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");
            ReadLine();
            Back();
        }

        public static void NewProductArray(string ProductCategory, string ProductManufacturer, string ProductName, string ProductManufactureDate, string ProductWarranty, string ProductProvider)
        {
            string[] ProductArray = new string[] { ProductCategory, ProductManufacturer, ProductName, ProductManufactureDate, ProductWarranty, ProductProvider };
            foreach (string PA in ProductArray)
            {
                WriteLine(PA);
            }
        }

        public static void NewWarehouseRecordArray(string ProductCategory, string ProductManufacturer, string ProductName, string ProductManufactureDate, string ProductWarranty, string ProductProvider)
        {
            string[] WarehouseRecordArray = new string[] { ProductCategory, ProductManufacturer, ProductName, ProductManufactureDate, ProductWarranty, ProductProvider };
            foreach (string WRA in WarehouseRecordArray)
            {
                WriteLine(WRA);
            }
        }

        public static void NewDescriptionArray(string ProductDescription)
        {
            string DescriptionArray = ProductDescription;
        }

        public static void NewMemoArray(string ProductNotes)
        {
            string MemoArray = ProductNotes;
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
