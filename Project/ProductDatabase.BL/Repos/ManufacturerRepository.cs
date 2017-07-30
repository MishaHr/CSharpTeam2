using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.DA;

namespace ProductDatabase.BL.Main_Classes
{
    /// <summary>
    /// Клас для добування Виробників
    /// </summary>
    public class ManufacturerRepository: AbstractRepository
    {
        //змінна вибору відповідного файлу бази даних (пізніше перероблю механізм)
         
        public ManufacturerRepository(): base ("Manufacturer")
        {

        }
       
    }
}
