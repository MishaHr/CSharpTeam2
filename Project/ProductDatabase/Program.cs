using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Reposirories;


namespace ProductDatabase
{
    class Program
    {
       
        static void Main(string [] args)
        {
            //Вхідна точка програми
            Console.OutputEncoding = Encoding.UTF8;
            //MainMenu.Show();
            TestReportsMenu.Show();



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
