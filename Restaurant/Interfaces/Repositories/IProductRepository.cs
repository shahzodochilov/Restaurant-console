using Restaurant.Interfaces.Common;
using Restaurant.Models;

namespace Restaurant.Interfaces.Repositories
{
    public interface IProductRepository :
        ICreateable<Product>, IReadable<Product>, IUpdateable<Product>, IDeleteable<Product>
    {

    }
}
