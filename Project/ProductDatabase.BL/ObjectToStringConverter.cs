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
        /// Метод формує скорочений Список Постачальників у текстовому форматі 
        /// (без телефону, тільки ІД та назва)
        /// </summary>
        /// <returns>скорочений Список постачальників у вигляді стрінгів</returns>
        public List<string> SuppliersListToText()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            List<string> suppliers = new List<string>();
            var supplierList = (List<Supplier>) supplierRepository.GetAll();

            foreach (var supplier in supplierList)
            {
                Text = $"{supplier.SupplierId}. {supplier.SupplierName}";
                suppliers.Add(Text);
            }
            return suppliers;
        }


        /// <summary>
        /// Метод формує повний Список Постачальників у текстовому форматі 
        /// (всі поля разом з телефоном)
        /// </summary>
        /// <returns>Повний Список постачальників у вигляді стрінгів</returns>
        public List<string> SuppliersListToTextFull()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            List<string> suppliers = new List<string>();
            var supplierList = (List<Supplier>)supplierRepository.GetAll();

            foreach (var supplier in supplierList)
            {
                Text = $"{supplier.SupplierId}. {supplier.SupplierName}, тел: {supplier.SupplierPhoneNumber}";
                suppliers.Add(Text);
            }
            return suppliers;
        }

        /// <summary>
        /// Метод перетворює об’єкт типу Manufacturer в стрінгу
        /// Викидає NullReferenceException
        /// </summary>
        /// <param name="id">ІД виробника</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string ManufacturerToText(int id)
        {
            ManufacturerRepository manufacturerRepository   =new ManufacturerRepository();
            Manufacturer man = manufacturerRepository.Get(id);
            try
            {
                string result = $"{man.ManufacturerId}. {man.ManufacturerName}";
                return result;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Виробника з таким ІД не існує");
            }
        }

        /// <summary>
        /// Метод формує Список Виробників у текстовому форматі
        /// </summary>
        /// <returns>Список Виробників у вигляді стрінгів</returns>
        public List<string> ManufacturerListToText()
        {
            ManufacturerRepository manufacturerRepository =new ManufacturerRepository();
            List<Manufacturer> manufacturerList = (List<Manufacturer>)manufacturerRepository.GetAll();
            List<string> manufacturerStringList = new List<string>();

            foreach (var man in manufacturerList)
            {
                Text = $"{man.ManufacturerId}. {man.ManufacturerName}";
                manufacturerStringList.Add(Text);
            }
            return manufacturerStringList;
        }



    }
}


