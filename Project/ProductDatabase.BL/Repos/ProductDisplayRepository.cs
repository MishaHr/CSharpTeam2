using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL.Main_Classes;

namespace ProductDatabase.BL.Repos
{
    /// <summary>
    /// Клас для добування необхідних даних длі відображення інформації про продукт
    /// </summary>
    public class ProductDisplayRepository
    {

        /// <summary>
        /// Метод для добування необхідної інформації з баз даних. Приймає ID продукту як вхідний параметр
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Повертає об’кт типу ProductDisplay, який мыстить необхыдну ынформацыю </returns>
        public ProductDisplay Retrive(int id)
        {
            //створюються необхідні репозиторії
            ProductDisplay report = new ProductDisplay();
            ProductRepository prodactData = new ProductRepository();
            CategoryRepository categoryData =new CategoryRepository();
            ManufacturerRepository manufacturerData = new ManufacturerRepository();

            //добуваються об’єкти згідно з ІД
            Product product = (Product)prodactData.Retrive(id);
            Category category = (Category)categoryData.Retrive(product.CategoryId);
            Manufacturer manufacturer = (Manufacturer)manufacturerData.Retrive(product.ManufacrirerId);

            //заповнюються відповідні поля та повертається результат
            report.ProductId = product.ProductId;
            report.CategoryName = category.CategoryName;
            report.ManufacturerName = manufacturer.ManufacturerName;
            report.ProductModel = product.ProductModel;


            return report;
        }

    }
}
