using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime DeliveryTime { get; set; }
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
                $"{Price};{Supplier};{SupplierPhoneNumber};{DeliveryTime};{WarehouseNumber};" +
                $"{Description};{Memo}");
        }
    }
}
