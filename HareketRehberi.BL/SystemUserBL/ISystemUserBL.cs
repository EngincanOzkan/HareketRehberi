using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.SystemUserBL
{
    public interface ISystemUserBL
    {
        Task<IEnumerable<SystemUser>> GetAll();
        Task<SystemUser> Get(int id);
        Task<SystemUser> GetByUserName(string userName);
        Task<SystemUser> Create(SystemUserRequest user);
        Task<SystemUser> Update(SystemUserRequest user);
        Task<SystemUser> Delete(int id);
    }
}
