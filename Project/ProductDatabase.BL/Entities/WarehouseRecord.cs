using System;

namespace ProductDatabase.BL.Entities
{
    internal class WarehouseRecord:BaseEntity
    {
        /// <summary>
        /// Клас зберігання записів навяності товару на складі (кількість, ціна, дата поставки)
        /// </summary>
        public int WarehouseNumber { get; set; }
        public int Ammount { get; set; }
        public double Price { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }

        public WarehouseRecord(int id):base(id)
        {
            
        }

        public override string ToString()
        {
            return string.Format($"{id};{WarehouseNumber};{Ammount};{Price};{DeliveryDate.Date.ToString("dd.MM.yyyy")};{SupplierId}");
        }
    }
}
