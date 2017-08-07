using System;
using static System.Convert;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;

namespace ProductDatabase.BL
{
        /// <summary>
        /// Клас для створення об’єктів на основі отриманих з текстових бази даних
        /// </summary>
    internal static class ObjectCreator
        {
            //private string _option;

            //public ObjectCreator(string option)
            //{
            //    _option = option;
            //}

           
            /// <summary>
        /// Створює об’єкт Товару
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>Об’єкт типу Product</returns>
        public static Product CreateProduct (string [] retrivedData )
        {
            Product product = new Product(ToInt32(retrivedData[0]));
                product.CategoryId = ToInt32(retrivedData[1]);
                product.ManufacrirerId = ToInt32(retrivedData[2]);
                product.ProductModel = retrivedData[3].Trim();
                product.ProductionDate = DateTime.Parse(retrivedData[4].Trim());
                product.ExpirationDate = retrivedData[5].Trim();
                return product;
            }

        /// <summary>
        /// Створює об’єкт Категорії
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>Об’єкт типу Category</returns>
        //public Category CreateCategory(string[] retrivedData)
        //{
        //    Category category = new Category(ToInt32(retrivedData[0]));
        //    category.CategoryName = retrivedData[1].Trim();
        //    return category;
        //}

        /// <summary>
        /// Створює об’єкт Виробника
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу Manufacturer</returns>
        public static Manufacturer CreateManufacturer(string[] retrivedData)
        {
            Manufacturer manufacturer = new Manufacturer(Convert.ToInt32(retrivedData[0]));
            manufacturer.ManufacturerName = retrivedData[1].Trim();
            return manufacturer;
        }

        /// <summary>
        /// Створює об’єкт Постачальника
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу Supplier</returns>
        public static Supplier CreateSupplier(string[] retrivedData)
        {
            Supplier supplier =new Supplier(ToInt32(retrivedData[0]));
            supplier.SupplierName = retrivedData[1];
            supplier.SupplierPhoneNumber = retrivedData[2];
            return supplier;
        }

        /// <summary>
        /// Створює об’єкт Приміток
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу Memo</returns>
        public static Memo CreateMemo(string[] retrivedData)
        {
            Memo memo = new Memo(ToInt32(retrivedData[0]));
            memo.MemoText = retrivedData[1];
            return memo;
        }

        /// <summary>
        /// Створює об’єкт WarehouseRecord
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу WarehouseRecord</returns>
        public static WarehouseRecord CreateWarehouseRecord (string[] retrivedData)
        {
            WarehouseRecord warehouseRecord = new WarehouseRecord(ToInt32(retrivedData[0]));
            warehouseRecord.WarehouseNumber = ToInt32(retrivedData[1]);
            warehouseRecord.Ammount = ToInt32(retrivedData[2]);
            warehouseRecord.Price = ToDouble(retrivedData[3]);
            warehouseRecord.DeliveryDate = ToDateTime(retrivedData[4]);
            warehouseRecord.SupplierId = ToInt32(retrivedData[5]);
            return warehouseRecord;
        }

        /// <summary>
        /// Створює об’єкт Короткого опису
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу ShortDescription</returns>
        public static ShortDescription CreateDescription(string[] retrivedData)
        {
            ShortDescription description =new ShortDescription(ToInt32(retrivedData[0]));
            description.DescriptionText = retrivedData[1];
            return description;
        }


    }
}
