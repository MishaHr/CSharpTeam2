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
                    AddProduct();
                    break;
            }
        }

        public static void AddProduct()
        {
            //WriteLine("0. Повернутися до попереднього меню");
            WriteLine("Список категорій"); // будуть відображатись доступні категорії для вибору
            Write("\nВведіть ID категорії зі списку : ");
            string ProductCategory = (ReadLine());
            //if (ProductCategory == "0")
            //{
            //    Back();
            //}
            Clear();
            WriteLine("Категорія : {0}", ProductCategory); // замсть ID має підібратися назва категорії

            WriteLine("\nСписок виробників"); // будуть відображатись доступні виробники товару для вибору
            Write("\nВведіть ID виробника зі списку : ");
            string ProductManufacturer = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);

            Write("\nВведіть назву товару : ");
            string ProductName = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);

            Write("\nВведіть дату виготовлення : "); // потрібно буде привести приклад правильного формату
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
            WriteLine("Гарантійний термін : {0}", ProductWarranty);

            WriteLine("\nСписок постачальників"); // будуть відображатись доступні виробники товару для вибору
            Write("\nВведіть ID постачальника зі списку : "); // потрібно буде привести приклад правильного формату
            string ProductProvider = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Номер телефону постачальника : 098 765 43 21");

            Write("\nВведіть кількість одиниць : ");
            string ProductAmount = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Номер телефону постачальника : 098 765 43 21");
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
            WriteLine("Номер телефону постачальника : 098 765 43 21");
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);

            Write("\nВведіть дату поставки : ");
            string ProductDeliveryDate = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Номер телефону постачальника : 098 765 43 21");
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);

            Write("\nВведіть номер складу : ");
            string ProductWarehouse = (ReadLine());
            Clear();
            WriteLine("Категорія : {0}", ProductCategory);
            WriteLine("Виробник : {0}", ProductManufacturer);
            WriteLine("Назва товару : {0}", ProductName);
            WriteLine("Дата виготовлення : {0}", ProductManufactureDate);
            WriteLine("Гарантійний термін : {0}", ProductWarranty);
            WriteLine("Постачальник : {0}", ProductProvider);
            WriteLine("Номер телефону постачальника : 098 765 43 21");
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
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
            WriteLine("Номер телефону постачальника : 098 765 43 21");
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
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
            WriteLine("Номер телефону постачальника : 098 765 43 21");
            WriteLine("Кількість одиниць : {0}", ProductAmount);
            WriteLine("Ціна за одиницю : {0}", ProductPrice);
            WriteLine("Дата поставки : {0}", ProductDeliveryDate);
            WriteLine("Номер складу : {0}", ProductWarehouse);
            WriteLine("Короткий опис : {0}", ProductDescription);
            WriteLine("Примітка : {0}", ProductNotes);

            WriteLine("\nІнформація введена успішно!");
            WriteLine("Натисніть будь яку клавіше для повернення до головного меню.");
            ReadLine();
            Back();
        }

        public static void Back()
        {
            MainMenu.Show();
        }
    }
}
