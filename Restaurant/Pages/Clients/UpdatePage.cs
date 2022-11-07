using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Clients
{
    public class UpdatePage
    {
        public static async Task RunAsync()
        {
            Client client = new Client();
            Console.WriteLine("******   Foydalanuvchi ma'lumotlarini yangilash    ******");
            Console.WriteLine("Foydalanuvchi Id sini kiriting :  ");
            int clientId = int.Parse(Console.ReadLine());
            client.Id = clientId;
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
            bool updated = await clientRepository.UpdateAsync(clientId, client);
            if (updated) StatusHelper.AcceptedMessage("Muvaffaqiyat yangilandi!");
            else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
