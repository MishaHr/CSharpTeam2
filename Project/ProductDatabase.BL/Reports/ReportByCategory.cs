﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Reports
{
    public class ReportByCategory
    
    {
        public int ID { get; private set; }
        public string Category { get; set; }
        public string  Manufacturer { get;  set; }
        public string Model { get;  set; }
        public string Description { get;  set; }
        public DateTime ProductionDate { get; set; }
        public string Memo { get;  set; }


        public ReportByCategory(int id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return string.Format($"Код: {ID}. {Manufacturer} {Model}\nДата виготовлення: {ProductionDate.ToString("dd.MM.yyyy")}" +
                                 $"\nКороткий опис:{Description}\nПримітка: {Memo}");
        }
    }
}
