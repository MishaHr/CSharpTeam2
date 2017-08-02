using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Reports;
using ProductDatabase.BL.Repos;

namespace ProductDatabase.BL
{

        /// <summary>
        /// Клас для побудови звітів
        /// </summary>
    internal class Report
    {

        /// <summary>
        /// Метод генерує звіт всіх товарів в вибраній категорії
        /// </summary>
        /// <param name="id">ІД категорії</param>
        /// <returns>Колекцію звітів ReportByCategory по вибраній категорії</returns>
        internal List<ReportByCategory> GenerateByCategory(int id)
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
            var query =
                from product in products
                join category in catgories on product.CategoryId equals category.CategoryId
                join manufacturer in manufacturers on product.ManufacrirerId equals manufacturer.ManufacturerId
                join description in descriptions on product.ProductId equals description.ProductId
                join memo in memos on product.ProductId equals memo.ProductId
                where product.CategoryId == id
                select new
                {
                    ID = product.ProductId,
                    Category = category.CategoryName,
                    Manufacturer = manufacturer.ManufacturerName,
                    Model = product.ProductModel,
                    Description = description.DescriptionText,
                    Memo = memo.MemoText

                };

            //Перетворення анонімниї об’єктів в об’єкти типу ReportByCategory та об’єднання їх у колекцію
            var list = query.ToList();
            List<ReportByCategory> result = new List<ReportByCategory>();
            foreach (var item in list)
            {
                ReportByCategory report = new ReportByCategory(item.ID);
                report.Category = item.Category;
                report.Manufacturer = item.Manufacturer;
                report.Model = item.Model;
                report.Description = item.Description;
                report.Memo = item.Memo;

                result.Add(report);
            }
           
            return result;

        }



        
    }
}
