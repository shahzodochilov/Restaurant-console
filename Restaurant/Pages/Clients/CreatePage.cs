using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Clients
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            Client client = new Client();
            Console.WriteLine("******   Foydalanuvchi qo'shish    ******");
            Console.WriteLine("Id :  ");
            client.Id = int.Parse(Console.ReadLine());
            Console.Write("Familiya-ism :  ");
            client.Name = Console.ReadLine();
            Console.WriteLine("-->>   Jinsini tanlang   <<--");
            Console.WriteLine("1. Erkak     2. Ayol");
            int selected = int.Parse(Console.ReadLine());
            client.Gender = (selected == 1) ? Enums.Gender.Male : Enums.Gender.Famale;
            Console.Write("Telefon nomeri :  ");
            client.PhoneNumber = Console.ReadLine();
            Console.Write("Manzili :  ");
            client.Address = Console.ReadLine();
            IClientRepository clientRepository = new ClientRepository();
            bool created = await clientRepository.CreateAsync(client);
            if (created) StatusHelper.AcceptedMessage("Muvaffaqiyat qo'shildi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
