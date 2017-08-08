using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Editors;
using ProductDatabase.BL.CustomExceptions;
using System.IO;

namespace ProductDatabase
{
    class ManufacturerMenu
    {
        public static void Show()
        {
            Title = "\tМеню роботи з базою \"Виробники\"";
            Clear();
            WriteLine("\tРедагування бази \"Виробники\"");
            WriteLine("\n1. Додати нового виробника");
            WriteLine("2. Редагувати існуючого виробника");
            WriteLine("3. Видалити існуючого виробника");
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
                    Show();
                    break;
            }
        }

        private static void AddManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            bool check = false;
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            string Name = null;
            do
            {
                Write("\nВведіть назву виробника : ");
                try
                {
                    Name = (ReadLine());
                    Validation.ManufacturerName(Name);

                    string[] userInput = { Name };
                    ManufacturerEditor editor = new ManufacturerEditor();
                    editor.Add(userInput);

                    Clear();
                    WriteLine("Назва виробника : {0}", Name);
                    WriteLine("\nВиробника введено успішно!");
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

        private static void EditManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            bool check = false;
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            string ManufacturerID = null;
            string ManufacturerName = null;
            do
            {
                Write("\nВведіть ID виробника : ");
                try
                {
                    ManufacturerID = Console.ReadLine();
                    Validation.Id(ManufacturerID);
                    int ManID = Convert.ToInt32(ManufacturerID);
                    ManufacturerName = display.ManufacturerToText(ManID);
                    check = true;
                    do
                    {
                        check = false;
                        Write("\nВведіть нову назву виробника : ");
                        try
                        {
                            ManufacturerName = Console.ReadLine();
                            Validation.ManufacturerName(ManufacturerName);
                            string[] edited = { ManufacturerID, ManufacturerName };
                            ManufacturerEditor editor = new ManufacturerEditor();
                            editor.Edit(edited);

                            WriteLine("Назву виробника змінено : {0}", ManufacturerName);
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

        private static void DeleteManufacturer()
        {
            ObjectToStringConverter display = new ObjectToStringConverter();
            bool check = false;
            WriteLine("Список існуючих виробників\n");
            var manufacturer = display.ManufacturerListToText();
            foreach (var man in manufacturer)
            {
                Console.WriteLine(man);
            }
            string ManID = null;
            int ManufacturerID;
            string ManufacturerName = null;
            do
            {
                Write("\nВведіть ID виробника : ");
                try
                {
                    ManID = Console.ReadLine();
                    Validation.Id(ManID);
                    ManufacturerID = Convert.ToInt32(ManID);

                    ManufacturerName = display.ManufacturerToText(ManufacturerID);
                    ManufacturerEditor editor = new ManufacturerEditor();
                    editor.Delete(ManufacturerID);

                    WriteLine("Виробника {0} видалено успішно!", ManufacturerName);
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
