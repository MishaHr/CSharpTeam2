using System;

namespace ProductDatabase.BL.Reports
{
    internal class WarehouseRecordReport
    {
        #region Properties
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }
        public string SupplierName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ExpirationDate { get; set; }
        public int WarehouseNumber { get; set; }
        #endregion

        public WarehouseRecordReport(int id)
        {
            ProductId = id;
        }

        public string ToPrint()
        {
            return string.Format($"Код: {ProductId}" +
                                 $"\nМодель: {ManufacturerName} {Model}" +
                                 $"\nКількість на скалді: {Ammount}" +
                                 $"\nЦіна: {Price}" +
                                 $"\nПостачальник: {SupplierName}" +
                                 $"\nДата поставки: {DeliveryDate.ToString("dd.MM.yyy")}" +
                                 $"\nТермін привдатності: {ExpirationDate}" +
                                 $"\nСклад №{WarehouseNumber}");
        }

        public override string ToString()
        {
            return string.Format($"{ProductId};{CategoryName};{ManufacturerName};{Model};" +
                                 $"{Ammount};{Price};{SupplierName};{DeliveryDate.ToString("dd.MM.yyy")};" +
                                 $"{ExpirationDate};{WarehouseNumber}");
        }
    }
}
