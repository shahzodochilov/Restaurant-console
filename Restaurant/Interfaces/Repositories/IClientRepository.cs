using Restaurant.Interfaces.Common;
using Restaurant.Models;

namespace Restaurant.Interfaces.Repositories
{
    public interface IClientRepository :
        ICreateable<Client>, IReadable<Client>, IUpdateable<Client>, IDeleteable<Client>
    {

    }
}
