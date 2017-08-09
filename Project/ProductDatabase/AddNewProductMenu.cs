using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using System.IO;
using ProductDatabase.BL.CustomExceptions;
using ProductDatabase.BL.Editors;

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
            /*змінна що вказую правельність проходження меню 
            (якщо вибивають помилки чек вертає для повторного проходження)*/
            bool check = false;
            //для запису в файл Product.dat
            string[] productToSave=new string [5];
            ProductEditor prodEditor = new ProductEditor();

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
            do
            {
                Write("\nВведіть ID категорії зі списку : ");
                try
                {
                    check = false;
                    CategoryID = Console.ReadLine();
                    Validation.Id(CategoryID);
                    productToSave[0] = CategoryID;
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
                    check = false;
                    ManufacturerID = Console.ReadLine();
                    Validation.Id(ManufacturerID);
                    productToSave[1] = ManufacturerID;
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
                    check = false;
                    ProductName = ReadLine();
                    Validation.ProductName(ProductName);
                    productToSave[2] = ProductName;
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
                Write("\nВведіть дату виготовлення (дд.мм.рррр): "); 
                //WriteAt(28, 4);
                try
                {
                    check = false;
                    ProductManufactureDate = ReadLine();
                    Validation.ProductionDate(ProductManufactureDate);
                    productToSave[3] = ProductManufactureDate;
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
                    check = false;
                    ProductWarranty = ReadLine();

                    Validation.ExpirationDateTxt(ProductWarranty);
                    productToSave[4] = ProductWarranty;
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

            //запис у файл Product.dat
            prodEditor.Add(productToSave);

            //для запису в файл WarehouseRecord.dat
            string[] warehouseToSave = new string[5];
            WarehouseRecordEditor warehouseEditor = new WarehouseRecordEditor();

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
                    check = false;
                    SupplierId = ReadLine();
                    Validation.Id(SupplierId);
                    warehouseToSave[4] = SupplierId;
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
                Write("\nВведіть дату поставки (дд.мм.рррр): ");
                //WriteAt(24, 7);
                try
                {
                    check = false;
                    ProductDeliveryDate = ReadLine();
                    Validation.DeliveryDate(ProductDeliveryDate);
                    warehouseToSave[3] = ProductDeliveryDate;
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
                    check = false;
                    ProductAmount = ReadLine();

                    Validation.Amount(ProductAmount);
                    warehouseToSave[1] = ProductAmount;
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
                    check = false;
                    ProductPrice = ReadLine();

                    Validation.Price(ProductPrice);
                    warehouseToSave[2] = ProductPrice;
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
                    check = false;
                    ProductWarehouse = ReadLine();
                    bool valid = Validation.WarehouseNumber(ProductWarehouse);
                    warehouseToSave[0] = ProductWarehouse;
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

            //запис у файл WarehouseRecord.dat
            warehouseEditor.Add(warehouseToSave);

            //для запису в файл ShortDescription.dat
            string[] shortDescriptionToSave = new string[1];
            ShortDescriptionEditor shortDescriptionEditor = new ShortDescriptionEditor();

            string ProductDescription = null;
            do
            {
                Write("\nВведіть короткий опис : ");
                try
                {
                    check = false;
                    ProductDescription = ReadLine();

                    Validation.ShortDescription(ProductDescription);
                    shortDescriptionToSave[0] = ProductDescription;
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

            //запис у файл ShortDescription.dat
            shortDescriptionEditor.Add(shortDescriptionToSave);

            //для запису в файл Memo.dat
            string[] memoToSave = new string[1];
            MemoEditor memoEditor = new MemoEditor();

            string ProductNotes = null;
            do
            {
                Write("\nЗаповніть поле для приміток якщо потрібно : ");
                try
                {
                    check = false;
                    ProductNotes = ReadLine();

                    Validation.Memo(ProductNotes);
                    memoToSave[0] = ProductNotes;
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

            //запис у файл Memo.dat
            memoEditor.Add(memoToSave);

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
