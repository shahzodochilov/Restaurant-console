using System.Threading.Tasks;

namespace Restaurant.Interfaces.Common
{
    public interface IDeleteable<T>
    {
        Task<bool> DeleteAsync(int id);
    }
}
