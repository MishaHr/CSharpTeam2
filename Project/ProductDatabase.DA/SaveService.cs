using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.DA
{
    /// <summary>
    /// Клас для запису інформації у файл. В розробці
    /// </summary>
    public static class SaveService
    {
        public static void WrightToFile(string toSave)
        {
            Console.WriteLine($"{toSave} saved succesfully");
        }
    }
}
