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
        /// <summary>
        /// Класс для перетворення об’єктів в стрінги та масиви стрінгів
        /// Необхідний для того, щоб передавати ці стрінги класам UI для виведення інформації у консоль
        /// </summary>

            private string Text { get; set; }

        /// <summary>
        /// Метод перетворюе об’єкт типу Category в стрінгу
        /// </summary>
        /// <param name="id">ІД категорії</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string CategoryToText(int id)
            {
                CategoryRepository categoryRepository = new CategoryRepository();
                Category cat = (Category)categoryRepository.Get(id);
                string result = $"{cat.CategoryId}. {cat.CategoryName}";
                return result;
            }

        /// <summary>
        /// Метод формує Список категорії у текстовому форматі
        /// </summary>
        /// <returns>Список категорій у вигляді стрінгів</returns>
        public List<string> CategoryListToText()
            {
            //Завантажуємо всі категорії з бази
                CategoryRepository categoryRepository = new CategoryRepository();
                List<string> strings = new List<string>();
                var categoryList = (List<Category>)categoryRepository.GetAll();

            //заповнюємо Ліст текстовим представленням кожного об’єкту Category
                foreach (var c in categoryList)
                {
                    Text = $"{c.CategoryId}. {c.CategoryName}";
                    strings.Add(Text);
                }
                return strings;
            }
        }
    }


