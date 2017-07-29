using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    /// <summary>
    /// Клас Постачальника продукції
    /// </summary>
    public class Supplier
    {
        
        public int SupplierId { get; private set; }
        public string SupplierName { get; set; }

        public Supplier(int supplierId)
        {
            SupplierId = supplierId;
        }
        public Supplier(int supplierId, string supplierName)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
        }

        public override string ToString()
        {
            return string.Format($"ID:{SupplierId} Name:{SupplierName}");
        }
        

    }
}
