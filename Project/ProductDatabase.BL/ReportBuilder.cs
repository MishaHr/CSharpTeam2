using System.Collections.Generic;
using System.Linq;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Reports;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL
{

    /// <summary>
    /// Клас для побудови звітів
    /// </summary>
    internal class ReportBuilder
    {

        /// <summary>
        /// Метод генерує короткий звіт всіх товарів
        /// </summary>
        /// <returns>Колекцію звітів ReportByCategory</returns>
        internal List<ShortProductReport> GenerateShortProductReport()
        {
            //ініціалізація потрібних репозиторіїв
            Repository<Product> productRepository = new Repository<Product>();
            Repository<Category> categoryRepository = new Repository<Category>();
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            Repository<ShortDescription> shortDescriptionRepository =new Repository<ShortDescription>();
            Repository<Memo> memoRepository = new Repository<Memo>();

            //завантаження всіх необхідних "таблиць" даних
            var products = productRepository.GetAll();
            var catgories = categoryRepository.GetAll();
            var manufacturers = manufacturerRepository.GetAll();
            var descriptions =  shortDescriptionRepository.GetAll();
            List<Memo> memos = memoRepository.GetAll();

            //об’єднання даних по ІД. Вибірка по необхідній категорії
            var list =
                (from product in products
                join category in catgories on product.CategoryId equals category.id
                join manufacturer in manufacturers on product.ManufacrirerId equals manufacturer.id
                join description in descriptions on product.id equals description.id
                join memo in memos on product.id equals memo.id
                select new
                {
                    ID = product.id,
                    Category = category.CategoryName,
                    Manufacturer = manufacturer.ManufacturerName,
                    Model = product.ProductModel,
                    Description = description.DescriptionText,
                    product.ProductionDate,
                    product.ExpirationDate,
                    Memo = memo.MemoText

                }).ToList();

            //Перетворення анонімних об’єктів в об’єкти типу ReportByCategory та об’єднання їх у колекцію
            List<ShortProductReport> result = new List<ShortProductReport>();
            foreach (var item in list)
            {
                ShortProductReport report = new ShortProductReport(item.ID);
                report.CategoryName = item.Category;
                report.Manufacturer = item.Manufacturer;
                report.Model = item.Model;
                report.Description = item.Description;
                report.ProductionDate = item.ProductionDate;
                report.ExpirationDate = item.ExpirationDate;
                report.Memo = item.Memo;

                result.Add(report);
            }
           
            return result;

        }

        /// <summary>
        /// Генерує повний звіт всіх товарів
        /// </summary>
        /// <returns>Ліст звітів FullProductReport</returns>
        internal List<FullProductReport> GenerateFullProductReport()
        {
            //ініціалізація потрібних репозиторіїв
            Repository<Product> productRepository = new Repository<Product>();
            Repository<Category> categoryRepository = new Repository<Category>();
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            Repository<ShortDescription> shortDescriptionRepository = new Repository<ShortDescription>();
            Repository<Memo> memoRepository = new Repository<Memo>();
            Repository<WarehouseRecord> warehouseRecordRepository = new Repository<WarehouseRecord>();
            Repository<Supplier> supplierRepository = new Repository<Supplier>();
           
            

            //завантаження всіх необхідних "таблиць" даних
            var products = productRepository.GetAll();
            var catgories = categoryRepository.GetAll();
            var manufacturers = manufacturerRepository.GetAll();
            var descriptions = shortDescriptionRepository.GetAll();
            List<Memo> memos = memoRepository.GetAll();
            var warehouseRecords = warehouseRecordRepository.GetAll();
            var suppliers = supplierRepository.GetAll();


            //об’єднання даних по ІД. Вибірка по необхідній категорії
            var list =
            (from product in products
                join category in catgories on product.CategoryId equals category.id
                join manufacturer in manufacturers on product.ManufacrirerId equals manufacturer.id
                join description in descriptions on product.id equals description.id
                join memo in memos on product.id equals memo.id
                join record in warehouseRecords on product.id equals record.id 
                select new
                {
                    ID = product.id,
                    Category = category.CategoryName,
                    Manufacturer = manufacturer.ManufacturerName,
                    Model = product.ProductModel,
                    product.ProductionDate,
                    product.ExpirationDate,
                    record.Ammount,
                    record.Price,
                    Supplier = (from supplier in suppliers
                                join warehouseRec in warehouseRecords on supplier.id equals record.SupplierId
                                select supplier.SupplierName).First(),
                    SupplierPhoneNumber = (from sup in suppliers
                                           join warehouse in warehouseRecords on sup.id equals  warehouse.SupplierId
                                           select sup.SupplierPhoneNumber).First(),
                    record.DeliveryDate,
                    record.WarehouseNumber,
                    Memo = memo.MemoText,
                    Description = description.DescriptionText
                    

                }).ToList();

            //Перетворення анонімних об’єктів в об’єкти типу ReportByCategory та об’єднання їх у колекцію
            List<FullProductReport> result = new List<FullProductReport>();
            foreach (var item in list)
            {
                FullProductReport report = new FullProductReport(item.ID);
                report.Category = item.Category;
                report.Manufacturer = item.Manufacturer;
                report.Model = item.Model;
                report.ProductionDate = item.ProductionDate;
                report.ExpirationDate = item.ExpirationDate;
                report.Ammount = item.Ammount;
                report.Price = item.Price;
                report.Supplier = item.Supplier;
                report.SupplierPhoneNumber = item.SupplierPhoneNumber;
                report.DeliveryDate = item.DeliveryDate;
                report.WarehouseNumber = item.WarehouseNumber;
                report.Description = item.Description;
                report.Memo = item.Memo;

                result.Add(report);
            }
            return result;
        }

        /// <summary>
        /// Генерує звіт товарів на складі WarehouseRecordReport
        /// </summary>
        /// <returns>Ліст звітів WarehouseRecordReport</returns>
        internal List<WarehouseRecordReport> GenerateWarehouseRecordReport()
        {
            Repository<Product> productRepository = new Repository<Product>();
            Repository<WarehouseRecord> warehouseRecordRepository = new Repository<WarehouseRecord>();
            Repository<Supplier> supplierRepository = new Repository<Supplier>();
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            Repository<Category> categoryRepository = new Repository<Category>();

            var products = productRepository.GetAll();
            var records = warehouseRecordRepository.GetAll();
            var suppliers = supplierRepository.GetAll();
            var manufacturers = manufacturerRepository.GetAll();
            var categories = categoryRepository.GetAll();

            var query = (
                from product in products
                join record in records on product.id equals record.id
                join manufacturer in manufacturers on product.ManufacrirerId equals manufacturer.id
                join warehouseRecord in records on product.id equals warehouseRecord.id
                join category in categories on product.CategoryId equals category.id 
                select new
                {
                    ProductId = product.id,
                    CategoryName = category.CategoryName,
                    manufacturer.ManufacturerName,
                    Model = product.ProductModel,
                    warehouseRecord.Ammount,
                    warehouseRecord.Price,
                    Supplier = (from supplier in suppliers
                        join record1 in records on supplier.id equals record.SupplierId
                        select supplier.SupplierName).First(),
                    warehouseRecord.DeliveryDate,
                    product.ExpirationDate,
                    warehouseRecord.WarehouseNumber
                }).ToList();

            List<WarehouseRecordReport> reportList = new List<WarehouseRecordReport>();
            foreach (var item in query)
            {
                WarehouseRecordReport report = new WarehouseRecordReport(item.ProductId);
                report.CategoryName = item.CategoryName;
                report.ManufacturerName = item.ManufacturerName;
                report.Model = item.Model;
                report.Ammount = item.Ammount;
                report.Price = item.Price;
                report.SupplierName = item.Supplier;
                report.DeliveryDate = item.DeliveryDate;
                report.ExpirationDate = item.ExpirationDate;
                report.WarehouseNumber = item.WarehouseNumber;

                reportList.Add(report);
            }
            return reportList;
        }
    }
}
