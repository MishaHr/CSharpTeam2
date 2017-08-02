using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;

namespace ProductDatabase.BL
{
    internal class ObjectCreator
    {
        private string Option { get; set; }
        //private string objectChoice { get; set; }

        public ObjectCreator(string option)
        {
           Option = option;
        }

        public Product CreateProduct (string [] retrivedData )
        {

            //else if (Option=="Category")
            Product product = new Product(ToInt32(retrivedData[0]));
                product.CategoryId = ToInt32(retrivedData[1]);
                product.ManufacrirerId = ToInt32(retrivedData[2]);
                product.ProductModel = retrivedData[3].Trim();
                return product;
            }

        public Category CreateCategory(string[] retrivedData)
        //else if (Option=="Category")
        {
            Category category = new Category(ToInt32(retrivedData[0]));
            category.CategoryName = retrivedData[1].Trim();
            return category;
        }

        public Manufacturer CreateManufacturer(string[] retrivedData)
       {
            //заповнюємо відповідні поля в об’єкту Manufacturer (це можна винести в майбутньому в окремий клас-Фабрику)
            Manufacturer manufacturer = new Manufacturer(Convert.ToInt32(retrivedData[0]));
            manufacturer.ManufacturerName = retrivedData[1].Trim();

            return manufacturer;

        }

        public Supplier CreateSupplier(string[] retrivedData)
        {
            Supplier supplier =new Supplier(ToInt32(retrivedData[0]));
            supplier.SupplierName = retrivedData[1];
            return supplier;
        }

        public Memo CreateMemo(string[] retrivedData)
        {
            Memo memo = new Memo(ToInt32(retrivedData[0]));
            memo.MemoText = retrivedData[1];
            return memo;
        }

        public WarehouseRecord CreateWarehouseRecord (string[] retrivedData)
        {
            WarehouseRecord warehouseRecord = new WarehouseRecord(ToInt32(retrivedData[0]));
            warehouseRecord.WarehouseNumber = ToInt32(retrivedData[1]);
            warehouseRecord.Ammmount = ToInt32(retrivedData[2]);
            warehouseRecord.Price = ToDouble(retrivedData[3]);
            warehouseRecord.DeliveryDate = ToDateTime(retrivedData[4]);
            warehouseRecord.SupplierId = ToInt32(retrivedData[5]);
            return warehouseRecord;
        }

        public ShortDescription CreateDescription(string[] retrivedData)
        {
            ShortDescription description =new ShortDescription(ToInt32(retrivedData[0]));
            description.DescriptionText = retrivedData[1];
            return description;
        }


    }
}
