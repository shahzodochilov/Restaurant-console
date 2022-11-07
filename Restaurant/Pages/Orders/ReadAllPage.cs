using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Interfaces.Services;
using Restaurant.Repositories;
using Restaurant.Services;
using System.Threading.Tasks;

namespace Restaurant.Pages.Orders
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            IOrderService orderService = new OrderService();
            var orderViewModels = await orderService.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Stol raqami", "Mijoz", "Ofitsant", "Hisob", "Vaqt");

            foreach (var orderViewModel in orderViewModels)
            {
                consoleTable.AddRow(orderViewModel.Id, orderViewModel.TableNumber, orderViewModel.ClientName, orderViewModel.EmployeeName, orderViewModel.TotalSum, orderViewModel.Date.ToString("dd/MM/yy HH:mm"));
            }
            consoleTable.Write();
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
