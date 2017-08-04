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
                join category in catgories on product.CategoryId equals category.CategoryId
                join manufacturer in manufacturers on product.ManufacrirerId equals manufacturer.ManufacturerId
                join description in descriptions on product.ProductId equals description.ProductId
                join memo in memos on product.ProductId equals memo.ProductId
                select new
                {
                    ID = product.ProductId,
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
            return null;
        }

        /// <summary>
        /// Генерує звіт товарів на складі WarehouseRecordReport
        /// </summary>
        /// <returns>Ліст звітів WarehouseRecordReport</returns>
        internal List<WarehouseRecordReport> GenerateWarehouseRecordReport()
        {
            return null;
        }




    }
}
