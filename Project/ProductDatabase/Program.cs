using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.BL;
using ProductDatabase.BL.Main_Classes;
using ProductDatabase.BL.Repos;


namespace ProductDatabase
{
    class Program
    {
       
        static void Main(string [] args)
        {
            //Вхідна точка програми
            Console.OutputEncoding = Encoding.UTF8;
            //MainMenu.Show();
            ProductRepository productRepository = new ProductRepository();
            CategoryRepository categoryRepository = new CategoryRepository();
            ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
            MemoRepository memoRepository = new MemoRepository();
            WarehouseRecordRepository whRepo = new WarehouseRecordRepository();
            ShowCategory.Show();


            //List<Product> products = (List<Product>)productRepository.GetAll();
            //List<Category> categories = (List<Category>)categoryRepository.GetAll();
            //List<Manufacturer> manufacturers = (List<Manufacturer>) manufacturerRepository.GetAll();
            //List<Memo> memosList = (List<Memo>)memoRepository.GetAll();


            //Console.WriteLine(memosList[0]);
            //Console.WriteLine();


            //products.ForEach(pr => Console.WriteLine(pr));
            //Console.WriteLine();
            //int id=1;
            //var prod =
            //    from product in products
            //    join category in categories
            //    on product.CategoryId equals category.CategoryId
            //    join manufacturer in manufacturers
            //    on product.ManufacrirerId equals manufacturer.ManufacturerId
            //    join memo in memosList
            //    on product.ProductId equals memo.ProductId
            //    where product.ProductId == id
            //    select new
            //    {
            //        ID = product.ProductId,
            //        Категорія = category.CategoryName,
            //        Виробник = manufacturer.ManufacturerName,
            //        Модель = product.ProductModel,
            //        Примітка = memo.MemoText

            //    };


            //foreach (var p in prod)
            //{
            //    Console.WriteLine(p);
            //}
            //Console.WriteLine();
            //var newProd = prod.First();

            //Console.WriteLine($"Код товару: {newProd.ID}\nКатегорія: {newProd.Категорія}\nВиробник: {newProd.Виробник}\nМодель: {newProd.Модель}\nПримітка: {newProd.Примітка}");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
