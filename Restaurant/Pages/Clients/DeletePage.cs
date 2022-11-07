using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Clients
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IClientRepository clientRepository = new ClientRepository();
            Console.Write("Foydalanuvchi Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await clientRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Foydalanuvchi muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Foydalanuvchi ma'lumotlarini o'chirib bo'lmadi");
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
