using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.SystemUserRepos
{
    public interface ISystemUserRepo : IBaseRepo<SystemUser>
    {
        Task<SystemUser> GetByUserNameAsync(string userName);
        Task<bool> AnyAsync(string userName, int? id);
    }
}
