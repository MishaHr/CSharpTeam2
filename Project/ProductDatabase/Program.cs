using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
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
            ShortDescriptionRepository descriptionRepository = new ShortDescriptionRepository();
            var descriptions = (List<ShortDescription>)descriptionRepository.GetAll();
            ProductRepository productRepository = new ProductRepository();
            var products = (List<Product>) productRepository.GetAll();
            MemoRepository memoRepository =new MemoRepository();
            var memos = (List<Memo>) memoRepository.GetAll();


            var info =
                from product in products
                join description in descriptions
                on product.ProductId equals description.ProductId
                join memo in memos
                on product.ProductId equals memo.ProductId
                
                select new
                {
                    ID = product.ProductId,
                    Model = product.ProductModel,
                    Description = description.DescriptionText,
                    Memo = memo.MemoText
                   
                };

            var inf = info.ToList();
          
            Console.WriteLine($"{inf[0].ID}. {inf[0].Model}.\nКороткий опис: {inf[0].Description}\nПримітка: {inf[0].Memo}");



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
