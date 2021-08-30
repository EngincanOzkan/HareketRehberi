using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.SystemUserRepos
{
    public interface ISystemUserRepo
    {
        Task<IEnumerable<SystemUser>> GetAllAsync();
        Task<SystemUser> GetAsync(int id);
        Task<SystemUser> CreateAsync(SystemUser user);
        Task<SystemUser> UpdateAsync(SystemUser user);
        Task<SystemUser> DeleteAsync(int id);
    }
}
