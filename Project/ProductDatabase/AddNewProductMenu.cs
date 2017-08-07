using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using System.IO;

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
            WriteLine("Список категорій\n");
            var Category = display.CategoryListToText();
            foreach (var cat in Category)
            {
                Console.WriteLine(cat);
            }
            string CategoryID = null;
            int CatID;
            string ProductCategory = null;
            Write("\nВведіть ID категорії зі списку : ");
            try
            {
                CategoryID = (Console.ReadLine());
                bool valid = Validation.Id(CategoryID);

                if (valid == true)
                {
                    CatID = Convert.ToInt32(CategoryID); ;
                    ProductCategory = display.CategoryToText(CatID);
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            WriteLine("\nСписок виробників\n");
            var Manufacturer = display.ManufacturerListToText();
            foreach (var man in Manufacturer)
            {
                Console.WriteLine(man);
            }
            Write("\nВведіть ID виробника зі списку : ");
            string ManufacturerID = (Console.ReadLine());
            int ManID;
            string ProductManufacturer = null;
            try
            {
                bool valid = Validation.Id(ManufacturerID);

                if (valid == true)
                {
                    ManID = Convert.ToInt32(ManufacturerID);
                    ProductManufacturer = display.ManufacturerToText(ManID);
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть назву товару : ");
            string ProductName = null;
            try
            {
                ProductName = ReadLine();
                bool valid = Validation.ProductName(ProductName);

                if (valid == true)
                {
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть дату виготовлення : 00.00.0000"); // потрібно буде привести приклад правильного формату
            WriteAt(28, 4);
            string ProductManufactureDate = null;
            try
            {
                ProductManufactureDate = ReadLine();
                bool valid = Validation.ProductionDate(ProductManufactureDate);

                if (valid == true)
                {
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть гарантійний термін : ");
            string ProductWarranty = null;
            try
            {
                ProductWarranty = ReadLine();
                bool valid = Validation.ExpirationDateTxt(ProductWarranty);

                if (valid == true)
                {
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0} років", ProductWarranty);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            WriteLine("\nСписок постачальників\n");
            var Suppliers = display.SuppliersListToTextShort();
            foreach (var sup in Suppliers)
            {
                Console.WriteLine(sup);
            }
            Write("\nВведіть ID постачальника зі списку : ");
            string SupplierId = null;
            int SupID;
            string ProductProvider = null;
            try
            {
                SupplierId = ReadLine();
                bool valid = Validation.Id(ManufacturerID);

                if (valid == true)
                {
                    SupID = Convert.ToInt32(SupplierId);
                    ProductProvider = display.SupplierToText(SupID);
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0}", ProductWarranty);
                    WriteLine("Постачальник : {0}", ProductProvider);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть дату поставки : 00.00.0000");
            WriteAt(24, 7);
            string ProductDeliveryDate = null;
            try
            {
                ProductDeliveryDate = ReadLine();
                bool valid = Validation.DeliveryDate(ProductDeliveryDate);

                if (valid == true)
                {
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0}", ProductWarranty);
                    WriteLine("Постачальник : {0}", ProductProvider);
                    WriteLine("Дата поставки : {0}", ProductDeliveryDate);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть кількість одиниць : ");
            string ProductAmount = null;
            try
            {
                ProductAmount = ReadLine();
                bool valid = Validation.Amount(ProductAmount);

                if (valid == true)
                {
                    Clear();
                    WriteLine("Категорія : {0}", ProductCategory);
                    WriteLine("Виробник : {0}", ProductManufacturer);
                    WriteLine("Назва товару : {0}", ProductName);
                    WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
                    WriteLine("Гарантійний термін : {0}", ProductWarranty);
                    WriteLine("Постачальник : {0}", ProductProvider);
                    WriteLine("Дата поставки : {0}", ProductDeliveryDate);
                    WriteLine("Кількість одиниць : {0}", ProductAmount);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть ціну за одиницю : ");
            string ProductPrice = null;
            try
            {
                ProductPrice = ReadLine();
                bool valid = Validation.Price(ProductPrice);

                if (valid == true)
                {
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
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть номер складу : ");
            string ProductWarehouse = null;
            try
            {
                ProductWarehouse = ReadLine();
                bool valid = Validation.WarehouseNumber(ProductWarehouse);

                if (valid == true)
                {
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
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nВведіть короткий опис : ");
            string ProductDescription = null;
            try
            {
                ProductDescription = ReadLine();
                bool valid = Validation.ShortDescription(ProductDescription);

                if (valid == true)
                {
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
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

            Write("\nЗаповніть поле для приміток якщо потрібно : ");
            string ProductNotes = null;
            try
            {
                ProductNotes = ReadLine();
                bool valid = Validation.Memo(ProductNotes);

                if (valid == true)
                {
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
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }

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
