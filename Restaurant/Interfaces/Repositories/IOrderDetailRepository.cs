using Restaurant.Interfaces.Common;
using Restaurant.Models;

namespace Restaurant.Interfaces.Repositories
{
    public interface IOrderDetailRepository :
        ICreateable<OrderDetail>, IReadable<OrderDetail>, IUpdateable<OrderDetail>, IDeleteable<OrderDetail>
    {
    }
}
