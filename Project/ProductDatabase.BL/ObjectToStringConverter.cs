﻿    using System;
    using System.Collections.Generic;
    using ProductDatabase.BL.Entities;
    using ProductDatabase.BL.Repositories;

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
                Repository<Category> categoryRepository = new Repository<Category>();
                Category cat = (Category)categoryRepository.Get(id);
                try
                {
                    string result = $"{cat.id}. {cat.CategoryName}";
                    return result;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException($"There is no Category with ID:{id}");
                }
        }

        /// <summary>
        /// Метод формує Список категорії у текстовому форматі
        /// </summary>
        /// <returns>Список категорій у вигляді стрінгів</returns>
        public List<string> CategoryListToText()
            {
            //Завантажуємо всі категорії з бази
            Repository<Category> categoryRepository = new Repository<Category>();
            List<string> strings = new List<string>();
                var categoryList = (List<Category>)categoryRepository.GetAll();

            //заповнюємо Ліст текстовим представленням кожного об’єкту Category
                try
                {
                    foreach (var c in categoryList)
                    {
                        Text = $"{c.id}. {c.CategoryName}";
                        strings.Add(Text);
                    }
                    strings.Sort();
                    return strings;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException($"There are no Categories");
                }
        }

        /// <summary>
        /// Метод перетворює об’єкт типу Supplier в стрінгу
        /// Викидає NullReferenceException
        /// </summary>
        /// <param name="id">ІД постачальника</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string SupplierToText(int id)
        {
           Repository<Supplier> supplierRepository = new Repository<Supplier>();
           Supplier supplier = (Supplier) supplierRepository.Get(id);
           try
           {
               string result =
                   $"{supplier.id}. {supplier.SupplierName}, тел:{supplier.SupplierPhoneNumber}";
                    return result;
           }
           catch (NullReferenceException e)
           {
                throw new NullReferenceException($"There is no Supplier with ID:{id}");
           }
        }

        /// <summary>
        /// Метод формує скорочений Список Постачальників у текстовому форматі 
        /// (без телефону, тільки ІД та назва)
        /// </summary>
        /// <returns>скорочений Список постачальників у вигляді стрінгів</returns>
        public List<string> SuppliersListToTextShort()
        {
            Repository<Supplier> supplierRepository = new Repository<Supplier>();
            List<string> suppliers = new List<string>();
            var supplierList = (List<Supplier>) supplierRepository.GetAll();

            try
            {
                foreach (var supplier in supplierList)
                {
                    Text = $"{supplier.id}. {supplier.SupplierName}";
                    suppliers.Add(Text);
                }
                suppliers.Sort();
                return suppliers;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("There are no Suppliers");
            }
        }


        /// <summary>
        /// Метод формує повний Список Постачальників у текстовому форматі 
        /// (всі поля разом з телефоном)
        /// </summary>
        /// <returns>Повний Список постачальників у вигляді стрінгів</returns>
        public List<string> SuppliersListToTextFull()
        {
            Repository<Supplier> supplierRepository = new Repository<Supplier>();
            List<string> suppliers = new List<string>();
            var supplierList = (List<Supplier>)supplierRepository.GetAll();
            try
            {
                foreach (var supplier in supplierList)
                {
                    Text = $"{supplier.id}. {supplier.SupplierName}, тел: {supplier.SupplierPhoneNumber}";
                    suppliers.Add(Text);
                }
                suppliers.Sort();
                return suppliers;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("There are no Suppliers");
            }
        }

        /// <summary>
        /// Метод перетворює об’єкт типу Manufacturer в стрінгу
        /// Викидає NullReferenceException
        /// </summary>
        /// <param name="id">ІД виробника</param>
        /// <returns>Стрінга, відповідно сформатована для виведення на екран</returns>
        public string ManufacturerToText(int id)
        {
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            Manufacturer man = (Manufacturer)manufacturerRepository.Get(id);
            try
            {
                string result = $"{man.id}. {man.ManufacturerName}";
                return result;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException($"There is no Manufacturer with ID:{id}");
            }
        }

        /// <summary>
        /// Метод формує Список Виробників у текстовому форматі
        /// </summary>
        /// <returns>Список Виробників у вигляді стрінгів</returns>
        public List<string> ManufacturerListToText()
        {
            Repository<Manufacturer> manufacturerRepository = new Repository<Manufacturer>();
            var manList = manufacturerRepository.GetAll();
            List<string> manufacturerStringList = new List<string>();
            try
            {
                foreach (var man in manList)
                {
                    Text = $"{man.id}. {man.ManufacturerName}";
                    manufacturerStringList.Add(Text);
                }
                manufacturerStringList.Sort();
                return manufacturerStringList;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("There are no Manufacturers");
            }
        }

        public  List<string> LastIdList()
        {
            Repository<LastIdKeeper> lastIdKeeperRepository = new Repository<LastIdKeeper>();
            List<LastIdKeeper> idList = lastIdKeeperRepository.GetAll();
            List<string> lastIdText = new List<string>();

            foreach (var lastId in idList)
            {
                Text =
                    $"Prod: {lastId.id}, Cat: {lastId.LastCategoryId}, Man: {lastId.LastManufacturerId}, Sup: {lastId.LastSupplierId}";
                lastIdText.Add(Text);
            }
            return lastIdText;
        }


    }
}


