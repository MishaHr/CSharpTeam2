using System;
using ProductDatabase.BL.Entities;
using static System.Convert;

namespace ProductDatabase.BL
{
        /// <summary>
        /// Клас для створення об’єктів на основі отриманих з текстових бази даних
        /// </summary>
    internal static class ObjectCreator
        {
            
           
            /// <summary>
        /// Створює об’єкт Товару
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>Об’єкт типу Product</returns>
        internal static Product CreateProduct (string [] retrivedData )
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
        internal static Category CreateCategory(string[] retrivedData)
        {
            Category category = new Category(ToInt32(retrivedData[0]));
            category.CategoryName = retrivedData[1].Trim();
            return category;
        }

        /// <summary>
        /// Створює об’єкт Виробника
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу Manufacturer</returns>
        internal static Manufacturer CreateManufacturer(string[] retrivedData)
        {
            Manufacturer manufacturer = new Manufacturer(ToInt32(retrivedData[0]));
            manufacturer.ManufacturerName = retrivedData[1].Trim();
            return manufacturer;
        }

        /// <summary>
        /// Створює об’єкт Постачальника
        /// </summary>
        /// <param name="retrivedData">Масив стрінгів, добутий з текстового файлу</param>
        /// <returns>>Об’єкт типу Supplier</returns>
        internal static Supplier CreateSupplier(string[] retrivedData)
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
        internal static Memo CreateMemo(string[] retrivedData)
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
        internal static WarehouseRecord CreateWarehouseRecord (string[] retrivedData)
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
        internal static ShortDescription CreateDescription(string[] retrivedData)
        {
            ShortDescription description =new ShortDescription(ToInt32(retrivedData[0]));
            description.DescriptionText = retrivedData[1];
            return description;
        }

        internal static LastIdKeeper CreateLastIdKeeper(string[] retrivedData)
        {
                LastIdKeeper lastIdKeeper = new LastIdKeeper(ToInt32(retrivedData[0]));
                lastIdKeeper.LastProductId = ToInt32(retrivedData[1]);
                lastIdKeeper.LastCategoryId = ToInt32(retrivedData[2]);
                lastIdKeeper.LastManufacturerId = ToInt32(retrivedData[3]);
                lastIdKeeper.LastSupplierId = ToInt32(retrivedData[4]);
                return lastIdKeeper;
        }



    }
}
