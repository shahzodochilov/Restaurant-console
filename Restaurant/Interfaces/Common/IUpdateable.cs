using System.Threading.Tasks;

namespace Restaurant.Interfaces.Common
{
    public interface IUpdateable<T>
    {
        Task<bool> UpdateAsync(int id, T obj);
    }
}
