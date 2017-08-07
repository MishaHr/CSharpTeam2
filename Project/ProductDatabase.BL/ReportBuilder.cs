using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Entities;
using ProductDatabase.BL.Reports;
using ProductDatabase.BL.Reposirories;

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
            ProductRepository productRepository = new ProductRepository();
            CategoryRepository categoryRepository = new CategoryRepository();
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
            ShortDescriptionRepository shortDescriptionRepository =new ShortDescriptionRepository();
            MemoRepository memoRepository = new MemoRepository();

            //завантаження всіх необхідних "таблиць" даних
            var products = (List<Product>) productRepository.GetAll();
            var catgories = (List<Category>) categoryRepository.GetAll();
            var manufacturers = (List<Manufacturer>) manufacturerRepository.GetAll();
            var descriptions = (List<ShortDescription>) shortDescriptionRepository.GetAll();
            List<Memo> memos = (List<Memo>)memoRepository.GetAll();

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
                    ProductionDate = product.ProductionDate,
                    ExpirationDate = product.ExpirationDate,
                    Memo = memo.MemoText

                }).ToList();

            //Перетворення анонімних об’єктів в об’єкти типу ReportByCategory та об’єднання їх у колекцію
            List<ShortProductReport> result = new List<ShortProductReport>();
            foreach (var item in list)
            {
                ShortProductReport report = new ShortProductReport(item.ID);
                report.Category = item.Category;
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
            ProductRepository productRepository = new ProductRepository();
            CategoryRepository categoryRepository = new CategoryRepository();
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
            WarehouseRecordRepository warehouseRecordRepository = new WarehouseRecordRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            ShortDescriptionRepository shortDescriptionRepository = new ShortDescriptionRepository();
            MemoRepository memoRepository = new MemoRepository();

            //завантаження всіх необхідних "таблиць" даних
            var products = (List<Product>)productRepository.GetAll();
            var catgories = (List<Category>)categoryRepository.GetAll();
            var manufacturers = (List<Manufacturer>)manufacturerRepository.GetAll();
            var descriptions = (List<ShortDescription>)shortDescriptionRepository.GetAll();
            List<Memo> memos = (List<Memo>)memoRepository.GetAll();
            var warehouseRecords = (List<WarehouseRecord>) warehouseRecordRepository.GetAll();
            var suppliers = (List<Supplier>) supplierRepository.GetAll();


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
                    ProductionDate = product.ProductionDate,
                    ExpirationDate = product.ExpirationDate,
                    Ammount = record.Ammount,
                    Price = record.Price,
                    Supplier = (from supplier in suppliers
                                join warehouseRec in warehouseRecords on supplier.id equals record.SupplierId
                                select supplier.SupplierName).First(),
                    SupplierPhoneNumber = (from sup in suppliers
                                           join warehouse in warehouseRecords on sup.id equals  warehouse.SupplierId
                                           select sup.SupplierPhoneNumber).First(),
                    DeliveryDate = record.DeliveryDate,
                    WarehouseNumber = record.WarehouseNumber,
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
            ProductRepository productRepository = new ProductRepository();
            WarehouseRecordRepository warehouseRecordRepository = new WarehouseRecordRepository();
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
            SupplierRepository supplierRepository = new SupplierRepository();

            var products = (List<Product>) productRepository.GetAll();
            var records = (List<WarehouseRecord>) warehouseRecordRepository.GetAll();
            var suppliers = (List<Supplier>) supplierRepository.GetAll();
            var manufacturers = (List<Manufacturer>) manufacturerRepository.GetAll();


            var query = (
                from product in products
                join record in records on product.id equals record.id
                join manufacturer in manufacturers on product.ManufacrirerId equals manufacturer.id
                join warehouseRecord in records on product.id equals warehouseRecord.id
                select new
                {
                    ProductId = product.id,
                    CategoryId = product.CategoryId,
                    ManufacturerName = manufacturer.ManufacturerName,
                    Model = product.ProductModel,
                    Ammount = warehouseRecord.Ammount,
                    Price = warehouseRecord.Price,
                    Supplier = (from supplier in suppliers
                        join record1 in records on supplier.id equals record.SupplierId
                        select supplier.SupplierName).First(),
                    DeliveryDate = warehouseRecord.DeliveryDate,
                    ExpirationDate = product.ExpirationDate,
                    WarehouseNumber = warehouseRecord.WarehouseNumber
                }).ToList();

            List<WarehouseRecordReport> reportList = new List<WarehouseRecordReport>();
            foreach (var item in query)
            {
                WarehouseRecordReport report = new WarehouseRecordReport(item.ProductId);
                report.CategoryId = item.CategoryId;
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
