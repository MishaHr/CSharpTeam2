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
    public  class SaveService
    {
        public  void WrightToFile(List<string> toSave)
        {
            foreach (string s in toSave)
            {
                Console.WriteLine(s);
            }
        }
    }
}
