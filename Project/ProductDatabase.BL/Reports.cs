using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Repos;

namespace ProductDatabase.BL
{
    internal class Reports
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<WarehouseRecord> WarehouseRecords { get; set; }
        public List<Memo> Memos { get; set; }
        public List<ShortDescription> ShortDescriptions { get; set; }

        public Reports()
        {
            ProductRepository productRepository = new ProductRepository();
            CategoryRepository categoryRepository =new CategoryRepository();
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
            SupplierRepository supplierRepository =new SupplierRepository();

        }
    }
}
