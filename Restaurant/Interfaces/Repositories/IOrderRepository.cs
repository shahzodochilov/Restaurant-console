using Restaurant.Interfaces.Common;
using Restaurant.Models;

namespace Restaurant.Interfaces.Repositories
{
    public interface IOrderRepository :
        ICreateable<Order>, IReadable<Order>, IUpdateable<Order>, IDeleteable<Order>
    {
    }
}
