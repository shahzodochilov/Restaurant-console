using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System.Threading.Tasks;

namespace Restaurant.Pages.Clients
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
            IClientRepository clientRepository = new ClientRepository();
            var clients = await clientRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Jinsi", "Telefon nomeri", "Manzili");

            foreach (var item in clients)
            {
                string gender;
                if (item.Gender == Enums.Gender.Male) gender = "Erkak";
                else gender = "Ayol";
                consoleTable.AddRow(item.Id, item.Name, gender, item.PhoneNumber, item.Address);
            }
            consoleTable.Write();
        }
    }
}
