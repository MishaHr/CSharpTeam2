using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Reports;
using ProductDatabase.BL.Reposirories;

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
			CategoryRepository categoryRepository = new CategoryRepository();
            var categories = (List<Category>)categoryRepository.GetAll();
            var reports = report.GenerateShortProductReport();

			//вибираэмо з Ліста звітів тільки ті, які відповідають ІД категорії
            var shortReportsList =
                (from rep in reports
                join cat in categories on rep.Category equals cat.CategoryName
				 where cat.CategoryId==id
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

        
    }
}
