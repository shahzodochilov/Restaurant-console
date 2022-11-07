using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Products
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IProductRepository productRepository = new ProductRepository();
            Console.Write("Maxsulot Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await productRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Maxsulot muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Maxsulot ma'lumotlarini o'chirib bo'lmadi");
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
