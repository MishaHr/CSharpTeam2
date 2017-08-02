    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProductDatabase.BL.Repos;

    namespace ProductDatabase.BL
    {
        public class ObjectToStringConverter
        {


            private string Text { get; set; }

            public string TextCategory(int id)
            {
                CategoryRepository categoryRepository = new CategoryRepository();
                Category cat = (Category)categoryRepository.Get(id);
                string result = $"{cat.CategoryId}. {cat.CategoryName}";
                return result;
            }

            public List<string> TextCategoryList()
            {
                CategoryRepository categoryRepository = new CategoryRepository();
                List<string> strings = new List<string>();
                var categoryList = (List<Category>)categoryRepository.GetAll();

                foreach (var c in categoryList)
                {
                    Text = $"{c.CategoryId}. {c.CategoryName}";
                    strings.Add(Text);
                }



                return strings;
            }
        }
    }


