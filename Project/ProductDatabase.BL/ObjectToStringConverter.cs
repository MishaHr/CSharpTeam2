    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProductDatabase.BL.Main_Classes;
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
        /// Метод перетворює об’єкт типу Category в стрінгу
        /// Викидає NullReferenceException
        /// </summary>
        /// <param name="id">ІД категорії</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string CategoryToText(int id)
        {
                CategoryRepository categoryRepository = new CategoryRepository();
                Category cat = (Category)categoryRepository.Get(id);
                try
                {
                    string result = $"{cat.CategoryId}. {cat.CategoryName}";
                    return result;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException("Категорії з таким ІД не існує");
                }
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

        /// <summary>
        /// Метод перетворює об’єкт типу Supplier в стрінгу
        /// Викидає NullReferenceException
        /// </summary>
        /// <param name="id">ІД постачальника</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string SupplierToText(int id)
        {
           SupplierRepository supplierRepository = new SupplierRepository();
           Supplier supplier = (Supplier) supplierRepository.Get(id);
           try
           {
               string result =
                   $"{supplier.SupplierId}. {supplier.SupplierName}, тел:{supplier.SupplierPhoneNumber}";
                    return result;
           }
           catch (NullReferenceException e)
           {
                throw new NullReferenceException("Постачальника з таким ІД не існує");
           }
        }

        /// <summary>
        /// Метод формує Список Постачальників у текстовому форматі
        /// </summary>
        /// <returns>Список постачальників у вигляді стрінгів</returns>
        public List<string> SuppliersToList()
        {
            //тимчасовий код для тестів
            List<string> list =new List<string>();
            list[0] = "1. Samsung";
            list[1] = "2. HP";
            return list;
        }

        /// <summary>
        /// Метод перетворює об’єкт типу Manufacturer в стрінгу
        /// Викидає NullReferenceException
        /// </summary>
        /// <param name="id">ІД виробника</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string ManufacturerToText(int id)
        {
            //тимчасовий код для тестів
            return "1. Samsung";
        }

        /// <summary>
        /// Метод формує Список Виробників у текстовому форматі
        /// </summary>
        /// <returns>Список Виробників у вигляді стрінгів</returns>
        public List<string> ManufacturerListToText()
        {
            //тимчасовий код для тестів
            List<string> list = new List<string>();
            list[0] = "1. Samsung";
            list[1] = "2. HP";
            return list;
        }



    }
}


