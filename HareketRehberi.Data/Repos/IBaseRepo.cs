using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T evaluation);
        Task<T> UpdateAsync(T evaluation);
        Task<T> DeleteAsync(int id);
    }
}
