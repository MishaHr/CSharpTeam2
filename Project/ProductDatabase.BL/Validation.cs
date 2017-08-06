using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductDatabase.BL
{
    public class Validation
    {
        /// <summary>
        /// Check is valid data
        /// </summary>
        //lenght of the fields (characters)
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
                    throw new CustomeException("ID should be between 1 to 2 147 483 647");
            else throw new CustomeException("ID should be a number between 1 to 2 147 483 647");
        }
        //2.Назва товару 
        public static bool ProductName(string str)
        {
            //"Length of the product name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                return true;
            else
                throw new CustomeException("Length of the product name shoud be up to 50 characters");
        }
        //3.Назва Категорії 
        public static bool CategoryName(string str)
        {
            //"Length of the category name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                return true;
            else
                throw new CustomeException("Length of the category name shoud be up to 50 characters");
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
                    throw new CustomeException("Production date should be before now");
            else
                throw new CustomeException("Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/06/2017.");
        }
        //5.Термін придатності
        public static bool ExpirationDateTxt(string str)
        {
            //"Length of the expiration date shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                return true;
            else
                throw new CustomeException("Length of the expiration date shoud be up to 50 characters");
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
                    throw new CustomeException("Amount should be between 0 to 2 147 483 647");
            else throw new CustomeException("Amount should be a number between 0 to 2 147 483 647");
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
                    throw new CustomeException("Price should be greater than zero");
            else
                throw new CustomeException("Price format should be like \"1345,978\"");
        }
        //8.Постачальник
        public static bool Supplier(string str)
        {
            //"Length of the supplier name shoud be up to 50 characters"
            string trimStr = str.Trim();
            if (trimStr.Length > 0 && trimStr.Length <= shortText)
                return true;
            else
                throw new CustomeException("Length of the supplier name shoud be up to 50 characters");
        }
        //9.Телефон постачальника
        public static bool TelephoneNumber(string str)
        {
            //"Format should be like this examples:380443905333, +380(44)3905333"
            Regex reg = new Regex("^\\+?[1-9]\\d\\d\\(?\\d\\d\\)?\\d{7}$");
            if (reg.IsMatch(str))
                return true;
            else
                throw new CustomeException("Format of the number should be like this examples:380443905333, +380(44)3905333");
        }
        //10.Дата поставки
        public static bool DeliveryDate(string str)
        {
            //"Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/12/2017. Later then now"
            DateTime date;
            if (DateTime.TryParse(str, out date))
                return true;
            else
                throw new CustomeException("Format should be \"dd/mm/yyyy\" or \"dd.mm.yyyy\". For example 01/12/2017.");
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
                    throw new CustomeException("Warehouse number should be between 1 to 2 147 483 647");
            else throw new CustomeException("Warehouse number should be a number between 1 to 2 147 483 647");
        }
        //12.Короткий опис
        public static bool ShortDescription(string str)
        {
            //"Length of the short description shoud be up to 100 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= longText)
                return true;
            else
                throw new CustomeException("Length of the short description shoud be up to 100 characters");
        }
        //13.Поле для приміток
        public static bool Memo(string str)
        {
            //"Length of the Memo shoud be up to 100 characters"
            string trimStr = str.Trim();
            if (trimStr.Length <= longText)
                return true;
            else
                throw new CustomeException("Length of the Memo shoud be up to 100 characters");
        }
    }

}

