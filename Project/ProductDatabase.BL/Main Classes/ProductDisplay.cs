using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDatabase.BL.Main_Classes
{
    /// <summary>
    /// Клас виводу повної інформації про Продукт в "читабельному" вигляді
    /// </summary>
    public class ProductDisplay
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public string ProductModel { get; set; }

        public ProductDisplay()
        {
            
        }

        public override string ToString()
        {
            return string.Format($"Product ID: {ProductId}\nCategory: {CategoryName}\nManufacturer: {ManufacturerName}\nModel: {ProductModel}");
        }
    }
}
