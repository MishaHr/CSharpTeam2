using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Reports
{
    internal class WarehouseRecordReport
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }
        public string SupplierName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ExpirationDate { get; set; }
        public int WarehouseNumber { get; set; }

        public WarehouseRecordReport(int id)
        {
            ProductId = id;
        }

        public override string ToString()
        {
            return string.Format($"Код: " +
                                 $"\nМодель: {ManufacturerName} {Model}" +
                                 $"\nКількість на скалді: {Ammount}" +
                                 $"\nЦіна: {Price}" +
                                 $"\nПостачальник: {SupplierName}" +
                                 $"\nДата поставки: {DeliveryDate.ToString("dd-MM-yyy")}" +
                                 $"\nТермін привдатності: {ExpirationDate}" +
                                 $"\nСклад №{WarehouseNumber}");
        }
    }
}
