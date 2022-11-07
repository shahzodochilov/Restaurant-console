using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Clients
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            IClientRepository clientRepository = new ClientRepository();
            Console.Write("Foydalanuvchi Id sini kiriting:  ");
            int id = int.Parse(Console.ReadLine());
            var item = await clientRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Jinsi", "Telefon nomeri", "Manzili");
            string gender;
            if (item.Gender == Enums.Gender.Male) gender = "Erkak";
            else gender = "Ayol";
            consoleTable.AddRow(item.Id, item.Name, gender, item.PhoneNumber, item.Address);
            consoleTable.Write();
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
