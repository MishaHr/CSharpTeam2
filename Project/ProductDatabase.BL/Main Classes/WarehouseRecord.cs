using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Main_Classes
{
    public class WarehouseRecord:IGetable
    {
        /// <summary>
        /// Клас зберігання записів навяності товару на складі ()кількість, ціна, дата поставки)
        /// </summary>
        public int ProductId { get; private set; }
        public int WarehouseNumber { get; set; }
        public int Ammmount { get; set; }
        public double Price { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }

        public WarehouseRecord(int productId)
        {
            ProductId = productId;
        }

        public override string ToString()
        {
            return string.Format($"{ProductId};{WarehouseNumber};{Ammmount};{Price};{DeliveryDate.Date.ToString("dd.MM.yyyy")};{SupplierId}");
        }
    }
}
