using HareketRehberi.Data.Repos.SystemUserRepos;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HareketRehberi.BL.SystemUserBL
{
    public class SystemUserBL : ISystemUserBL
    {
        private readonly ISystemUserRepo _systemUserRepo;

        public SystemUserBL(ISystemUserRepo systemUserRepo)
        {
            _systemUserRepo = systemUserRepo;
        }

        public async Task<IEnumerable<SystemUser>> GetAll()
        {
            var users = await _systemUserRepo.GetAllAsync();
            return users;
        }

        public async Task<SystemUser> Get(int id)
        {
            var user = await _systemUserRepo.GetAsync(id);
            return user;
        }

        public async Task<SystemUser> GetByUserName(string userName)
        {
            var user = await _systemUserRepo.GetByUserNameAsync(userName);
            return user;
        }

        public async Task<SystemUser> Create(SystemUserRequest userRequest)
        {
            if (await IsUserExists(userRequest.UserName, null)) throw new System.Exception("Kullanıcı adı daha önceden alınmış!!!");

            using var hmac = new HMACSHA512();
            var user = new SystemUser
            {
                UserName = userRequest.UserName,
                Email = userRequest.Email,
                Phone = userRequest.Phone,
                IsAdmin = userRequest.IsAdmin,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password)),
                PasswordKey = hmac.Key
            };

            var userCrearted = await _systemUserRepo.CreateAsync(user);
            return userCrearted;
        }

        public async Task<SystemUser> Update(SystemUserRequest userRequest)
        {
            if (await IsUserExists(userRequest.UserName, userRequest.Id) || userRequest.Id == null || userRequest.Id == 0) throw new System.Exception("Kullanıcı adı daha önceden alınmış!!!");

            using var hmac = new HMACSHA512();
            var user = new SystemUser
            {
                Id = (int)userRequest.Id,
                UserName = userRequest.UserName,
                Email = userRequest.Email,
                Phone = userRequest.Phone,
                IsAdmin = userRequest.IsAdmin,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password)),
                PasswordKey = hmac.Key
            };

            var userUpdated = await _systemUserRepo.UpdateAsync(user);
            return userUpdated;
        }

        public async Task<SystemUser> Delete(int id)
        {
            var userDeleted = await _systemUserRepo.DeleteAsync(id);
            return userDeleted;
        }

        private async Task<bool> IsUserExists(string userName, int? id)
        {
            return await _systemUserRepo.AnyAsync(userName, id);
        }
    }
}
