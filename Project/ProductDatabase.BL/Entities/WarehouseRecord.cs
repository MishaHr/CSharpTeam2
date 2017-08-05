using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Entities
{
    public class WarehouseRecord:IGetable
    {
        /// <summary>
        /// Клас зберігання записів навяності товару на складі (кількість, ціна, дата поставки)
        /// </summary>
        public int ProductId { get; private set; }
        public int WarehouseNumber { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }

        public WarehouseRecord(int productId)
        {
            ProductId = productId;
        }

        public override string ToString()
        {
            return string.Format($"{ProductId};{WarehouseNumber};{Ammount};{Price};{DeliveryDate.Date.ToString("dd.MM.yyyy")};{SupplierId}");
        }
    }
}
