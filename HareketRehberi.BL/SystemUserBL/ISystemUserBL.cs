using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.SystemUserBL
{
    public interface ISystemUserBL
    {
        Task<IEnumerable<SystemUser>> GetAll();
        Task<SystemUser> Get(int id);
        Task<SystemUser> Create(SystemUser user);
        Task<SystemUser> Update(SystemUser user);
        Task<SystemUser> Delete(int id);
    }
}
