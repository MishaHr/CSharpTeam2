using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    public static class Validation
    {
        /// <summary>
        /// Check is valid data
        /// </summary>

        //1.ID-товару 
        public static bool Id(string str)
        {
            //"ID should be between 1 to 2 147 483 647"
            int id;
            if (int.TryParse(str, out id))
                if (id > 0)
                    return true;
            return false;
        }
        //2.Назва товару 
        public static bool ProductName(string str)
        {
            //"Length of the product name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= 50)
                return true;
            else return false;
        }
        //3.Назва Категорії 
        public static bool CategoryName(string str)
        {
            //"Length of the category name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= 50)
                return true;
            else return false;
        }
        //4.Дата виготовлення
        public static bool ProductionDate(string str)
        {
            //"Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/06/2017. Befor now"
            DateTime date;
            if (DateTime.TryParse(str, out date) && date < DateTime.Now)
                return true;
            else
                return false;
        }
        //5.Термін придатності
        public static bool ExpirationDateTxt(string str)
        {
            //"Length of the expiration date shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= 50)
                return true;
            else return false;
        }
        //6.Кількість одиниць
        public static bool Amount(string str)
        {
            //"Amount should be between 0 to 2 147 483 647"
            int id;
            if (int.TryParse(str, out id))
                if (id >= 0)
                    return true;
            return false;
        }
        //7.Ціна за одиницю
        public static bool Price(string str)
        {
            //"Price format should be like "1345,978" and greater than zero"
            double price;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            if (Double.TryParse(str, style, culture, out price) && price >= 0)
                return true;
            else
                return false;
        }
        //8.Постачальник
        public static bool Supplier(string str)
        {
            //"Length of the supplier name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= 50)
                return true;
            else return false;
        }
        //9.Телефон постачальника
        public static bool TelephoneNumber(string str)
        {
            //"Format should be like this examples:380443905333, +380(44)3905333"
            Regex reg = new Regex("^\\+?[1-9]\\d\\d\\(?\\d\\d\\)?\\d{7}$");
            if (reg.IsMatch(str))
                return true;
            else
                return false;
        }
        //10.Дата поставки
        public static bool DeliveryDate(string str)
        {
            //"Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/12/2017. Later then now"
            DateTime date;
            if (DateTime.TryParse(str, out date) && date > DateTime.Now)
                return true;
            else
                return false;
        }
        //11.Номер складу
        public static bool WarehouseNumber(string str)
        {
            //"WarehouseNumber should be between 1 to 2 147 483 647"
            int warehouseNumber;
            if (int.TryParse(str, out warehouseNumber))
                if (warehouseNumber > 0)
                    return true;
            return false;
        }
        //12.Короткий опис
        public static bool ShortDescription(string str)
        {
            //"Length of the short description shoud be up to 100 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= 100)
                return true;
            else return false;
        }
        //13.Поле для приміток
        public static bool Memo(string str)
        {
            //"Length of the Memo shoud be up to 100 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= 100)
                return true;
            else return false;
        }

    }
}

