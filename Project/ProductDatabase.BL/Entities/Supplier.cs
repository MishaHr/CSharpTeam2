using ProductDatabase.BL.Entities;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас Постачальника продукції
    /// </summary>
    internal class Supplier:BaseEntity
    {

        internal string SupplierName { get; set; }
        internal string SupplierPhoneNumber { get; set; }

        public Supplier(int id) : base (id)
        {
            
        }

    
        public override string ToString()
        {
            return string.Format($"{id};{SupplierName};{SupplierPhoneNumber}");
        }


    }
}
