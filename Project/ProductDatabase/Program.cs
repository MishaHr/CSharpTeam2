using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Repos;


namespace ProductDatabase
{
    class Program
    {
       
        static void Main(string [] args)
        {
            //Вхідна точка програми
            int ID = 2;
            ProductDisplayRepository loadReport = new ProductDisplayRepository();
            ProductDisplay report1 = loadReport.Retrive(ID);
            Console.WriteLine(report1);
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
