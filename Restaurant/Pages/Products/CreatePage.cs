using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Products
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Product product = new Product();
            Console.WriteLine("******   Maxsulot qo'shish    ******");
            Console.WriteLine("Id :  ");
            product.Id = int.Parse(Console.ReadLine());
            Console.Write("Name :  ");
            product.Name = Console.ReadLine();
            Console.Write("Narxi :  ");
            product.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("-->>   Maxsulot tipini tanlang   <<--");
            Console.WriteLine("1. Ovqat     2. Ichimlik  3. Salat");
            int selected = int.Parse(Console.ReadLine());
            product.Type = (Enums.ProductType) selected-1;
            IProductRepository productRepository = new ProductRepository();
            bool created = await productRepository.CreateAsync(product);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat qo'shildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
