using System.Collections.Generic;
using System.Linq;
using ProductDatabase.BL.Reports;
using ProductDatabase.BL.Repositories;


namespace ProductDatabase.BL
{
    public static class TextReportShower
    {
		/// <summary>
        /// метод призначений для підготовки короткого текстового звіту по товарам 
        /// з вібиркою по ІД категорії
        /// </summary>
        /// <param name="id">ІД категорії</param>
        /// <returns>Ліст стрінгів, що містить текстове представлення короткого звіту</returns>
        public static List<string> ShowShortReportByCategory(int id)
        {
           
            ReportBuilder report = new ReportBuilder();
			Repository<Category> categoryRepository = new Repository<Category>();
            var categories = categoryRepository.GetAll();
            var reports = report.GenerateShortProductReport();

			//вибираэмо з Ліста звітів тільки ті, які відповідають ІД категорії
            var shortReportsList =
                (from rep in reports
                join cat in categories on rep.CategoryName equals cat.CategoryName
				 where cat.id==id
                 select rep
				 ).ToList();

			//заповнюємо Ліст стрінгів текстовим представленням звітів
            List<string> strings = new List<string>();
            foreach (ShortProductReport r in shortReportsList)
            {
                strings.Add(r.ToString());
            }
            return strings;
        }

        /// <summary>
        /// Підготовляє повний звіт по всіх товарах
        /// </summary>
        /// <returns>Ліст стрінгів всієї інформації по всіх товарах</returns>
        public static List<string> ShowFullProductReport()
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            var fullReports = reportBuilder.GenerateFullProductReport();

            List<string> textFullProductReports = new List<string>();
            foreach (FullProductReport report in fullReports)
            {
                textFullProductReports.Add(report.ToPrint());
            }
            return textFullProductReports;
        }

        public static List<string> ShowFullProductReportByCategory(int categoryId)
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            Repository<Category> categoryRepository = new Repository<Category>();
            var categories = categoryRepository.GetAll();
            var fullReports = reportBuilder.GenerateFullProductReport();

            var filteredList = (
                from fullReport in fullReports
                join category in categories on fullReport.Category equals category.CategoryName
                where category.id == categoryId
                select fullReport).ToList();

            List<string> textFullProductReports = new List<string>();
            foreach (FullProductReport report in filteredList)
            {
                textFullProductReports.Add(report.ToPrint());
            }
            return textFullProductReports;
        }

        public static List<string> ShowFullWarehousereport()
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            var fullWarehouseReport = reportBuilder.GenerateWarehouseRecordReport();

            List<string> textWarehouseReport = new List<string>();
            foreach (WarehouseRecordReport report in fullWarehouseReport)
            {
                textWarehouseReport.Add(report.ToString());
            }
            return textWarehouseReport;
        }

        public static List<string> ShowWarehouseReportByCategory(int id)
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            var fullWarehouseReport = reportBuilder.GenerateWarehouseRecordReport();
            Repository<Category> categoryRepository = new Repository<Category>();
            var categories = categoryRepository.GetAll();

            var reportList =
            (from report in fullWarehouseReport
                join category in categories on report.CategoryName equals category.CategoryName 
                where category.id == id
                select report).ToList();

            List<string> textReport = new List<string>();
            foreach (var record in reportList)
            {
                textReport.Add(record.ToPrint());
            }
            return textReport;
        }

       

    }
}
