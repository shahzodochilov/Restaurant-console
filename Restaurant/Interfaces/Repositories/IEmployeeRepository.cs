using Restaurant.Interfaces.Common;
using Restaurant.Models;

namespace Restaurant.Interfaces.Repositories
{
    public interface IEmployeeRepository :
        ICreateable<Employee>, IReadable<Employee>, IUpdateable<Employee>, IDeleteable<Employee>
    {
    }
}
