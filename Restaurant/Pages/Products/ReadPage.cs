using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Products
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            IProductRepository productRepository = new ProductRepository();
            Console.WriteLine("Maxsulot Id sini kiriting");
            int id = int.Parse(Console.ReadLine());
            var product = await productRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Narxi", "Turi");
            string type;
            if (product.Type == Enums.ProductType.Meal) type = "Ovqat";
            else if (product.Type == Enums.ProductType.Drink) type = "Ichimlik";
            else type = "Salat";
            consoleTable.AddRow(product.Id, product.Name, product.Price, type);

            consoleTable.Write();
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
