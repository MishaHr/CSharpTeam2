using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Reports;

namespace ProductDatabase.BL
{
    public static class Controller
    {
        public static List<string> ShowByCategory(int id)
        {
            Report report = new Report();
            var reportsByCategories = report.GenerateByCategory(id);
            List<string> strings = new List<string>();
            foreach (ReportByCategory r in reportsByCategories)
            {
                strings.Add(r.ToString());
            }
            return strings;
        }

        
    }
}
