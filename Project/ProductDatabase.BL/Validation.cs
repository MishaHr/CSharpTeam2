using ProductDatabase.BL.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    public class Validation
    {
        /// <summary>
        /// Перевіряє коректність введених даних (продуктів, постачальників, складу..)
        /// </summary>
        //довжина текстових полів (назв, приміток, описів..)
        static int shortText = 50, longText = 100;

        //1.ID-товару 
        public static bool Id(string str)
        {
            //"ID should be between 1 to 2 147 483 647"
            int id;
            if (int.TryParse(str, out id))
                if (id > 0)
                    return true;
                else
                    throw new CustomeException("ID повинно бути від 1 до 2 147 483 647");
            else throw new CustomeException("ID повинно бути число від 1 до 2 147 483 647");
        }
        //2.Назва товару 
        public static bool ProductName(string str)
        {
            //"Length of the product name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина назви продукту повинна бути до {shortText} символів");
        }
        //3.Назва Категорії 
        public static bool CategoryName(string str)
        {
            //"Length of the category name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина назви категорії повинна бути до {shortText} символів");
        }
        //4.Дата виготовлення
        public static bool ProductionDate(string str)
        {
            //"Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/06/2017. Befor now"
            DateTime date;
            if (DateTime.TryParse(str, out date))
                if (date < DateTime.Now)
                    return true;
                else
                    throw new CustomeException($"Дата виготовлення повинна бути до {DateTime.Now.ToShortDateString()}");
            else
                throw new CustomeException("Формат дати повинен бути \"dd/mm/yyyy\" або \"dd.mm.yyyy\". Для прикладу 01/06/2017.");
        }
        //5.Термін придатності
        public static bool ExpirationDateTxt(string str)
        {
            //"Length of the expiration date shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина поля тексту придатності повинна бути до {shortText} символів");
        }
        //6.Кількість одиниць
        public static bool Amount(string str)
        {
            //"Amount should be between 0 to 2 147 483 647"
            int id;
            if (int.TryParse(str, out id))
                if (id >= 0)
                    return true;
                else
                    throw new CustomeException("Кількість повинна бути від 0 до 2 147 483 647");
            else throw new CustomeException("Кількість повинна бути число від 0 до 2 147 483 647");
        }
        //7.Ціна за одиницю
        public static bool Price(string str)
        {
            //"Price format should be like "1345,978" and greater than zero"
            double price;
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            if (Double.TryParse(str, style, culture, out price))
                if (price >= 0)
                    return true;
                else
                    throw new CustomeException("Ціна повинна бути не менша 0");
            else
                throw new CustomeException("Формат введення ціни має бути як в даному прикладі \"1345,978\"");
        }
        //8.Постачальник
        public static bool Supplier(string str)
        {
            //"Length of the supplier name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина поля Постачальник повинна бути до {shortText} символів");
        }
        //9.Телефон постачальника
        public static bool TelephoneNumber(string str)
        {
            //"Format should be like this examples:380443905333, +380(44)3905333"
            Regex reg = new Regex("^\\+?[1-9]\\d\\d\\(?\\d\\d\\)?\\d{7}$");
            if (reg.IsMatch(str))
                return true;
            else
                throw new CustomeException("Форма номеру телефона повинен бути як вказано в прикладах:380443905333, +380(44)3905333");
        }
        //10.Дата поставки
        public static bool DeliveryDate(string str)
        {
            //"Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/12/2017. Later then now"
            DateTime date;
            if (DateTime.TryParse(str, out date))
                return true;
            else
                throw new CustomeException("Формат дати повинен бути \"dd/mm/yyyy\" або \"dd.mm.yyyy\". Для прикладу 01/06/2017.");
        }
        //11.Номер складу
        public static bool WarehouseNumber(string str)
        {
            //"WarehouseNumber should be between 1 to 2 147 483 647"
            int warehouseNumber;
            if (int.TryParse(str, out warehouseNumber))
                if (warehouseNumber > 0)
                    return true;
                else
                    throw new CustomeException("Номер складу повинен бути від 1 до 2 147 483 647");
            else throw new CustomeException("Номер складу повинно бути число від 1 до 2 147 483 647");
        }
        //12.Короткий опис
        public static bool ShortDescription(string str)
        {
            //"Length of the short description shoud be up to 100 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= longText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина поля Короткий опис повинна бути до {longText} символів");
        }
        //13.Поле для приміток
        public static bool Memo(string str)
        {
            //"Length of the Memo shoud be up to 100 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= longText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина поля Короткий опис повинна бути до {longText} символів");
        }
        //14.Назва виробника 
        public static bool ManufacturerName(string str)
        {
            //"Length of the product name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                if (!str.Contains(";"))
                    return true;
                else
                    throw new CustomeException("В цьому полі не можна використовувати \";\"");
            else
                throw new CustomeException($"Довжина назви виробника повинна бути до {shortText} символів");
        }
    }
}

