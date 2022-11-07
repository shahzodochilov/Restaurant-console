using System.Threading.Tasks;

namespace Restaurant.Interfaces.Common
{
    public interface ICreateable<T>
    {
        Task<bool> CreateAsync(T obj);
    }
}
