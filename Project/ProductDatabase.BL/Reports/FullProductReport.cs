using System;

namespace ProductDatabase.BL.Reports
{
    public class FullProductReport
    {
        public int ProductId { get; private set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ExpirationDate { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int WarehouseNumber { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }

        public FullProductReport(int id)
        {
            ProductId = id;
        }

        public override string ToString()
        {
            return string.Format(
                $"{ProductId};{Category};{Manufacturer};{Model};" +
                $"{ProductionDate.ToString("dd.MM.yyyy")};{ExpirationDate};{Ammount};" +
                $"{Price};{Supplier};{SupplierPhoneNumber};{DeliveryDate.ToString("dd.MM.yyyy")};{WarehouseNumber};" +
                $"{Description};{Memo}");
        }

        public string ToPrint()
        {
            return string.Format($"Код: {ProductId}" +
                                 $"\nКатегорія: {Category}" +
                                 $"\nМодель: {Manufacturer} {Model}" +
                                 $"\nДата виробництва: {ProductionDate.ToString("dd.MM.yyy")}" +
                                 $"\nТермін придатності: {ExpirationDate}" +
                                 $"\nКількість: {Ammount}" +
                                 $"\nЦіна: {Price}" +
                                 $"\nПостачальник: {Supplier} тел: {SupplierPhoneNumber}" +
                                 $"\nДата поставки: {DeliveryDate.ToString("dd.MM.yyyy")}" +
                                 $"\nСклад №{WarehouseNumber}" +
                                 $"\nКороткий опис: {Description}" +
                                 $"\nПримітка: {Memo}");
        }
    }
}
