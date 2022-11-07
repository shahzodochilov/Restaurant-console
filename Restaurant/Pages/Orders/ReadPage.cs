using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System;
using System.Threading.Tasks;

namespace Restaurant.Pages.Orders
{
    public class ReadPage
    {
        public static async Task RunAsync()
        {
            IEmployeeRepository EmployeeRepository = new EmployeeRepository();
            Console.WriteLine("Xodim Id sini kiriting : ");
            int id = int.Parse(Console.ReadLine());
            var employee = await EmployeeRepository.GetAsync(id);

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Yoshi", "Maoshi", "Telefon nomeri", "Mansabi", "Jinsi", "Manzili");
            string gender;
            if (employee.Gender == Enums.Gender.Male) gender = "Erkak";
            else gender = "Ayol";
            string position;
            if (employee.Position == Enums.EmployeePosition.Gurd) position = "Qorovul";
            else if (employee.Position == Enums.EmployeePosition.Manager) position = "Menejer";
            else if (employee.Position == Enums.EmployeePosition.Waiter) position = "Ofitsiant";
            else if (employee.Position == Enums.EmployeePosition.Cooker) position = "Oshpaz";
            else position = "Boshliq";

            consoleTable.AddRow(employee.Id, employee.Name, employee.Age, employee.Salary, employee.PhoneNumber, position, gender, employee.Address);

            consoleTable.Write();
            await RoutingHelper.MakeFooterAsync();
        }
    }
}
