using Restaurant.Helpers;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages
{
    public class MainPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Foydalanuvchilar");
            Console.WriteLine("2. Maxsulotlar");
            Console.WriteLine("3. Xodimlar");
            Console.WriteLine("4. Buyurtmalar");
            Console.WriteLine("5. Buyurtma ma'lumotlari");
            Console.WriteLine("6. Chiqish");


        key:
            string selected = Console.ReadLine();
            if (selected == "1") await ClientPage.RunAsync();
            else if (selected == "2") await ProductPage.RunAsync();
            else if (selected == "3") await EmployeePage.RunAsync();
            else if (selected == "4") await OrderPage.RunAsync();

            else if (selected == "6") return;
            else
            {
                StatusHelper.WrongMessage("Tanlovda xatolik bor! \nIltimos qayta tanlovni bajaring!");
                goto key;
            }
        }
    }
}
