using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Editors;
using System.IO;
using ProductDatabase.BL.CustomExceptions;

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
            //змінна що вказую правельність проходження меню 
            bool check = false;

            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToTextShort();
            foreach (var sup in suppliers)
            {
                Console.WriteLine(sup);
            }
            string SupplierName = null;
            string SupplierPhone = null;
            do
            {
                check = false;
                Write("\nВведіть назву постачальника : ");
                try
                {
                    SupplierName = ReadLine();
                    Validation.Supplier(SupplierName);
                    check = true;
                    do
                    {
                        check = false;
                        Write("\nВведіть номер телефону постачальника (формат +380987654321): ");
                        try
                        {
                            SupplierPhone = ReadLine();
                            Validation.TelephoneNumber(SupplierPhone);

                            string[] userInput = { SupplierName, SupplierPhone };
                            SupplierEditor added = new SupplierEditor();
                            added.Add(userInput);
                            Clear();
                            WriteLine("Назва постачальника : {0}", SupplierName);
                            WriteLine("Номер телефону постачальника : {0}", SupplierPhone);
                            WriteLine("\nПостачальника введено успішно!");
                            WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
                            ReadLine();
                            Show();
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
        }

        private static void EditSuppliers()
        {
            //змінна що вказую правельність проходження меню 
            bool check = false;
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToTextFull();
            foreach (var sup in suppliers)
            {
                Console.WriteLine(sup);
            }
            string SupplierId = null;
            string SupplierName = null;
            string SupplierPhone = null;
            do
            {
                check = false;
                Write("\nВведіть ID постачальника : ");
                try
                {
                    SupplierId = Console.ReadLine();
                    Validation.Id(SupplierId);
                    int SuppId = Convert.ToInt32(SupplierId);
                    string SupplierInfo = display.SupplierToText(SuppId);
                    check = true;
                    do
                    {
                        check = false;
                        Write("\nВведіть нову назву постачальника : ");
                        try
                        {
                            SupplierName = ReadLine();
                            Validation.Supplier(SupplierName);
                            check = true;
                            do
                            {
                                check = false;
                                Write("\nВведіть номер телефону постачальника (формат +380987654321): ");
                                try
                                {
                                    SupplierPhone = ReadLine();
                                    Validation.TelephoneNumber(SupplierPhone);

                                    string[] edited = { SupplierId, SupplierName, SupplierPhone };
                                    SupplierEditor editor = new SupplierEditor();
                                    editor.Edit(edited);

                                    WriteLine("\nДані постачальника змінено : {0}, тел: {1}", SupplierName, SupplierPhone);
                                    WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
                                    ReadLine();
                                    Show();
                                    Clear();
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
        }

        private static void DeleteSuppliers()
        {
            //змінна що вказую правельність проходження меню 
            bool check = false;
            ObjectToStringConverter display = new ObjectToStringConverter();
            WriteLine("Список існуючих постачальників\n");
            var suppliers = display.SuppliersListToTextFull();
            foreach (var sup in suppliers)
            {
                Console.WriteLine(sup);
            }
            do
            {
                check = false;
                Write("\nВведіть ID постачальника : ");
                try
                {
                    string SuppId = Console.ReadLine();
                    Validation.Id(SuppId);
                    int SupplierId = Convert.ToInt32(SuppId);

                    string SupplierInfo = display.SupplierToText(SupplierId);
                    SupplierEditor editor = new SupplierEditor();
                    editor.Delete(SupplierId);

                    WriteLine("\nПостачальника {0} видалено успішно!", SupplierInfo);
                    WriteLine("Натисніть будь яку клавішу для повернення до попереднього меню.");
                    ReadLine();
                    Show();
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
        }
    }
}
