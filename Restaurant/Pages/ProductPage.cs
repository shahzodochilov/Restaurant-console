using Restaurant.Helpers;
using Restaurant.Pages.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Pages
{
    public class ProductPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha Maxsulot Ro'yxati");
            Console.WriteLine("2. Ma'lum maxsulot  ma'lumotlari");
            Console.WriteLine("3. Maxsulot qo'shish");
            Console.WriteLine("4. Maxsulot ma'lumotlarini o'zgartirish");
            Console.WriteLine("5. Maxsulot ma'lumotlarini o'chirish");
            Console.WriteLine("6. Bosh sahifa / Chiqish");

        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ReadAllPage.RunAsync();
            else if (selected == "2") await ReadPage.RunAsync();
            else if (selected == "3") await CreatePage.RunAsync();
            else if (selected == "4") await UpdatePage.RunAsync();
            else if (selected == "5") await DeletePage.RunAsync();
            else if (selected == "6") await RoutingHelper.MakeFooterAsync();

            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }

        }
    }
}
