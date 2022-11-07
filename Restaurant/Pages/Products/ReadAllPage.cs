using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System.Threading.Tasks;

namespace Restaurant.Pages.Products
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();
            await RoutingHelper.MakeFooterAsync();
        }
        public static async Task ShowDataAsync()
        {
            IProductRepository productRepository = new ProductRepository();
            var products = await productRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Nomi", "Narxi", "Turi");

            foreach (var item in products)
            {
                string type;
                if (item.Type == Enums.ProductType.Meal) type = "Ovqat";
                else if (item.Type == Enums.ProductType.Drink) type = "Ichimlik";
                else type = "Salat";
                consoleTable.AddRow(item.Id, item.Name, item.Price, type);
            }
            consoleTable.Write();
        }

    }
}
