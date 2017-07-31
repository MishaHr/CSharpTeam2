using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;

namespace ProductDatabase.BL
{
    public class ObjectCreator
    {
        private string Option { get; set; }
        //private string objectChoice { get; set; }

        public ObjectCreator(string option)
        {
           Option = option;
        }

        public Product GetProduct (string [] retrivedData )
        {

            //else if (Option=="Category")
            Product product = new Product(ToInt32(retrivedData[0]));
                product.CategoryId = ToInt32(retrivedData[1]);
                product.ManufacrirerId = ToInt32(retrivedData[2]);
                product.ProductModel = retrivedData[3].Trim();
                return product;
            }

        public Category GetCategory(string[] retrivedData)
        //else if (Option=="Category")
        {
            Category category = new Category(ToInt32(retrivedData[0]));
            category.CategoryName = retrivedData[1].Trim();
            return category;
        }

        public Manufacturer GetManufacturer(string[] retrivedData)
        //else if (Option == "Manufacturer")
        {
            //заповнюємо відповідні поля в об’єкту Manufacturer (це можна винести в майбутньому в окремий клас-Фабрику)
            Manufacturer manufacturer = new Manufacturer(Convert.ToInt32(retrivedData[0]));
            manufacturer.ManufacturerName = retrivedData[1].Trim();

            return manufacturer;

        }

        public Supplier GetSupplier(string[] retrivedData)
        {
            Supplier supplier =new Supplier(ToInt32(retrivedData[0]));
            supplier.SupplierName = retrivedData[1];
            return supplier;
        }



    }
}
