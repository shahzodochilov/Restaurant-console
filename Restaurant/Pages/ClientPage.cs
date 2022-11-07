﻿using Restaurant.Helpers;
using Restaurant.Pages.Clients;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages
{
    public class ClientPage
    {
        public static async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("1. Barcha Foydalanuvchilar Ro'yxati");
            Console.WriteLine("2. Ma'lum foydalanuvchi  ma'lumotlari");
            Console.WriteLine("3. Foydalanuvchi qo'shish");
            Console.WriteLine("4. Foydalanuvchi ma'lumotlarini o'zgartirish");
            Console.WriteLine("5. Foydalanuvchi ma'lumotlarini o'chirish");
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