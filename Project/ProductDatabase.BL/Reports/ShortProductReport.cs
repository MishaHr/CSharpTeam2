using System;

namespace ProductDatabase.BL.Reports
{
    public class ShortProductReport
    
    {
        #region Properties
        public int ID { get; private set; }
        public string CategoryName { get; set; }
        public string  Manufacturer { get;  set; }
        public string Model { get;  set; }
        public string Description { get;  set; }
        public DateTime ProductionDate { get; set; }
        public string ExpirationDate { get; set; }
        public string Memo { get;  set; }
        #endregion

        public ShortProductReport(int id)
        {
            ID = id;
        }

        public  string ToPrint()
        {
            return string.Format($"Код: {ID}" +
                                 $"Категорія: {CategoryName}" +
                                 $"\nМодель: {Manufacturer} {Model}" +
                                 $"\nДата виготовлення: {ProductionDate.ToString("dd.MM.yyyy")}" +
                                 $"\nТермін придатності: {ExpirationDate}" +
                                 $"\nКороткий опис:{Description}" +
                                 $"\nПримітка: {Memo}");
        }

        public override string ToString()
        {
            return string.Format($"{ID};{CategoryName};{Manufacturer};{Model};{ProductionDate.ToString("dd.MM.yyyy")};" +
                                 $"{ExpirationDate};{Description};{Memo}");
        }
    }
}
