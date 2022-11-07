using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Employees
{
    public class DeletePage
    {
        public static async Task RunAsync()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            Console.Write("Xodim Id sini kiriting: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = await employeeRepository.DeleteAsync(id);
            if (deleted) StatusHelper.AcceptedMessage("Xodim muvaffaqiyatli o'chirildi");
            else StatusHelper.WrongMessage("Xodim ma'lumotlarini o'chirib bo'lmadi");
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
