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
    public class Supplier:ISaveable
    {

    public int SupplierId { get; private set; }
    public string SupplierName { get; set; }

    public Supplier(int supplierId)
    {
        SupplierId = supplierId;
    }

    
    public override string ToString()
    {
        return string.Format($"{SupplierId};{SupplierName}");
    }


    }
}
