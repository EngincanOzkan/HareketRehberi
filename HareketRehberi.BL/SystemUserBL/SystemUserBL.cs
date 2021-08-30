using AutoMapper;
using HareketRehberi.Data.Repos.SystemUserRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Text.Json;
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

        public async Task<SystemUser> Create(SystemUser user)
        {
            var userCrearted = await _systemUserRepo.CreateAsync(user);
            return userCrearted;
        }

        public async Task<SystemUser> Update(SystemUser user)
        {
            var userUpdated = await _systemUserRepo.UpdateAsync(user);
            return userUpdated;
        }

        public async Task<SystemUser> Delete(int id)
        {
            var userDeleted = await _systemUserRepo.DeleteAsync(id);
            return userDeleted;
        }
    }
}
