using Restaurant.Helpers;
using Restaurant.Interfaces.Services;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Orders
{
    public class CreatePage
    {
        public static async Task RunAsync()
        {
            IOrderService orderService = new OrderService();
            OrderCreationalViewModel orderCreationalViewModel = new OrderCreationalViewModel();
            Console.WriteLine("******   Buyurtma qo'shish    ******");
            Console.WriteLine("Id :  ");
            orderCreationalViewModel.Id = int.Parse(Console.ReadLine());
            Console.Write("Stol raqami :  ");
            orderCreationalViewModel.TableNumber = int.Parse(Console.ReadLine());

            StatusHelper.InfoMessage("Mijozlar ro'yxati");
            await Pages.Clients.ReadAllPage.ShowDataAsync();
            Console.WriteLine("Mijoz Id sini kiriting");
            orderCreationalViewModel.ClientId = int.Parse(Console.ReadLine());

            StatusHelper.InfoMessage("Ofitsiantlar ro'yxati");
            await Pages.Employees.ReadAllPage.ShowDataAsync();
            Console.WriteLine("Ofitsiant Id sini kiriting");
            orderCreationalViewModel.EmployeeId = int.Parse(Console.ReadLine());

            Console.WriteLine("<---  Buyurtma uchun maxsulot qo 'shish!   --->");
            StatusHelper.InfoMessage("Maxsulotlar ro'yxati");
            await Pages.Products.ReadAllPage.ShowDataAsync();
        key:
            Console.Write("Maxsulot Id sini kiriting :  ");
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ProductId = int.Parse(Console.ReadLine());
            orderCreationalViewModel.OrderDetails.Add(new OrderDetail { ProductId = orderDetail.ProductId });
            StatusHelper.AcceptedMessage("Muvaffaqiyatli !");
            StatusHelper.InfoMessage("Yana qo'shishni xoxlaysizmi?\n 1. Ha             2. Yo'q");
            int selected = int.Parse(Console.ReadLine());
            if (selected == 1) goto key;
            else
            {
                orderCreationalViewModel.Date = DateTime.Now;
                bool res = await orderService.CreateAsync(orderCreationalViewModel);
                if (res) StatusHelper.AcceptedMessage("Muvaffaqiyat qo'shildi!");
                else StatusHelper.WrongMessage("Qandaydir xatolik aniqlandi!");
                await RoutingHelper.MakeFooterAsync();
            }
        }
    }
}
