using ConsoleTables;
using Restaurant.Helpers;
using Restaurant.Interfaces.Repositories;
using Restaurant.Repositories;
using System.Threading.Tasks;

namespace Restaurant.Pages.Employees
{
    public class ReadAllPage
    {
        public static async Task RunAsync()
        {
            await ShowDataAsync();
            await RoutingHelper.MakeFooterAsync();
        }
        public static async Task ShowDataAsync()
        {
            IEmployeeRepository EmployeeRepository = new EmployeeRepository();
            var Employees = await EmployeeRepository.GetAllAsync();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Ismi", "Yoshi", "Maoshi", "Telefon nomeri", "Mansabi", "Jinsi", "Manzili");

            foreach (var item in Employees)
            {
                string gender;
                if (item.Gender == Enums.Gender.Male) gender = "Erkak";
                else gender = "Ayol";
                string position;
                if (item.Position == Enums.EmployeePosition.Gurd) position = "Qorovul";
                else if (item.Position == Enums.EmployeePosition.Manager) position = "Menejer";
                else if (item.Position == Enums.EmployeePosition.Waiter) position = "Ofitsiant";
                else if (item.Position == Enums.EmployeePosition.Cooker) position = "Oshpaz";
                else position = "Boshliq";

                consoleTable.AddRow(item.Id, item.Name, item.Age, item.Salary, item.PhoneNumber, position, gender, item.Address);
            }
            consoleTable.Write();
        }
    }
}
