using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using System.IO;
using ProductDatabase.BL.CustomExceptions;

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
            Title = "Меню додавання нового товару";
            ObjectToStringConverter display = new ObjectToStringConverter();
            bool check = false;

            WriteLine("Список категорій\n");
            var Category = display.CategoryListToText();
            foreach (var cat in Category)
            {
                Console.WriteLine(cat);
            }
            string CategoryID = null;
            int CatID;
            string ProductCategory = null;
            do
            {
                Write("\nВведіть ID категорії зі списку : ");
                try
                {
                    CategoryID = Console.ReadLine();

                    Validation.Id(CategoryID);

                    CatID = Convert.ToInt32(CategoryID); ;
                    ProductCategory = display.CategoryToText(CatID);
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
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
            }
            while (!check);

            WriteLine("\nСписок виробників\n");
            var Manufacturer = display.ManufacturerListToText();
            foreach (var man in Manufacturer)
            {
                Console.WriteLine(man);
            }
            string ManufacturerID = null;
            int ManID;
            string ProductManufacturer = null;
            do
            {
                Write("\nВведіть ID виробника зі списку : ");
                try
                {
                    ManufacturerID = Console.ReadLine();

                    Validation.Id(ManufacturerID);

                    ManID = Convert.ToInt32(ManufacturerID);
                    ProductManufacturer = display.ManufacturerToText(ManID);
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    check = true;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FileNotFoundException fnfe)
                {
                    Console.WriteLine(fnfe.Message);
                }
                catch (CustomeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!check);

            string ProductName = null;
            do
            {
                Write("\nВведіть назву товару : ");
                try
                {
                    ProductName = ReadLine();

                    Validation.ProductName(ProductName);

                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
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
            }
            while (!check);

            string ProductManufactureDate = null;
            do
            {
                Write("\nВведіть дату виготовлення : 00.00.0000"); // потрібно буде привести приклад правильного формату
                WriteAt(28, 4);
                try
                {
                    ProductManufactureDate = ReadLine();

                    Validation.ProductionDate(ProductManufactureDate);

                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
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
            }
            while (!check);

            string ProductWarranty = null;
            Write("\nВведіть гарантійний термін : ");
            do
            {
                try
                {
                    ProductWarranty = ReadLine();

                    Validation.ExpirationDateTxt(ProductWarranty);

                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0} років", ProductWarranty);
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
            }
            while (!check);

            WriteLine("\nСписок постачальників\n");
            var Suppliers = display.SuppliersListToTextShort();
            foreach (var sup in Suppliers)
            {
                Console.WriteLine(sup);
            }
            string SupplierId = null;
            int SupID;
            string ProductProvider = null;
            do
            {
                Write("\nВведіть ID постачальника зі списку : ");
                try
                {
                    SupplierId = ReadLine();

                    Validation.Id(ManufacturerID);

                    SupID = Convert.ToInt32(SupplierId);
                    ProductProvider = display.SupplierToText(SupID);
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0}", ProductWarranty);
                    WriteLine("Постачальник : {0}", ProductProvider);
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
            }
            while (!check);

            string ProductDeliveryDate = null;
            do
            {
                Write("\nВведіть дату поставки : 00.00.0000");
                WriteAt(24, 7);
                try
                {
                    ProductDeliveryDate = ReadLine();
                    Validation.DeliveryDate(ProductDeliveryDate);

                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0}", ProductWarranty);
                    WriteLine("Постачальник : {0}", ProductProvider);
                    WriteLine("Дата поставки : {0}", ProductDeliveryDate);
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
            }
            while (!check);

            string ProductAmount = null;
            do
            {
                Write("\nВведіть кількість одиниць : ");
                try
                {
                    ProductAmount = ReadLine();

                    Validation.Amount(ProductAmount);

                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0}", ProductWarranty);
                    WriteLine("Постачальник : {0}", ProductProvider);
                    WriteLine("Дата поставки : {0}", ProductDeliveryDate);
                    WriteLine("Кількість одиниць : {0}", ProductAmount);
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
            }
            while (!check);

            string ProductPrice = null;
            do
            {
                Write("\nВведіть ціну за одиницю : ");
                try
                {
                    ProductPrice = ReadLine();

                    Validation.Price(ProductPrice);

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
            }
            while (!check);

            string ProductWarehouse = null;
            do
            {
                Write("\nВведіть номер складу : ");

                try
                {
                    ProductWarehouse = ReadLine();
                    bool valid = Validation.WarehouseNumber(ProductWarehouse);

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
            }
            while (!check);

            string ProductDescription = null;
            do
            {
                Write("\nВведіть короткий опис : ");
                try
                {
                    ProductDescription = ReadLine();

                    Validation.ShortDescription(ProductDescription);

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
            }
            while (!check);

            string ProductNotes = null;
            do
            {
                Write("\nЗаповніть поле для приміток якщо потрібно : ");
                try
                {
                    ProductNotes = ReadLine();

                    Validation.Memo(ProductNotes);

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
            }
            while (!check);

            WriteLine("\nІнформація введена успішно!");
            WriteLine("Натисніть будь яку клавішу для повернення до головного меню.");

            ReadLine();
            Back();
        }

        public static void NewProductArray(string CategoryID, string ManufacturerID, string ProductName, string ProductManufactureDate, string ProductWarranty, string SupplierId)
        {
            string[] ProductArray = new string[] { CategoryID, ManufacturerID, ProductName, ProductManufactureDate, ProductWarranty, SupplierId };
            foreach (string PA in ProductArray)
            {
                WriteLine(PA);
            }
        }

        public static void NewWarehouseRecordArray(string ProductWarehouse, string ProductAmount, string ProductPrice, string ProductDeliveryDate)
        {
            string[] WarehouseRecordArray = new string[] { ProductWarehouse, ProductAmount, ProductPrice, ProductDeliveryDate };
            foreach (string WRA in WarehouseRecordArray)
            {
                WriteLine(WRA);
            }
        }

        public static void NewDescriptionArray(string ProductDescription)
        {
            string DescriptionArray = ProductDescription;
            WriteLine(DescriptionArray);
        }

        public static void NewMemoArray(string ProductNotes)
        {
            string MemoArray = ProductNotes;
            WriteLine(MemoArray);
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
