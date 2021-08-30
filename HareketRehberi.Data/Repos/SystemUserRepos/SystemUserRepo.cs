using AutoMapper;
using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.SystemUserRepos
{
    public class SystemUserRepo : ISystemUserRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SystemUserRepo(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SystemUser>> GetAllAsync()
        {
            return await _context.SystemUsers.ToListAsync();
        }

        public async Task<SystemUser> GetAsync(int id)
        {
            return await _context.SystemUsers.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<SystemUser> GetByUserNameAsync(string userName) {
            return await _context.SystemUsers.FirstOrDefaultAsync(q => q.UserName == userName);
        }

        public async Task<SystemUser> CreateAsync(SystemUser user)
        {
            await _context.SystemUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<SystemUser> UpdateAsync(SystemUser user)
        {
            var userTemp = await this.GetAsync(user.Id);
            if (userTemp != null)
            {
                userTemp.UserName = user.UserName;
                userTemp.Email = user.Email;
                userTemp.Phone = user.Phone;
                userTemp.IsAdmin = user.IsAdmin;
                userTemp.PasswordHash = user.PasswordHash;
                userTemp.PasswordKey = user.PasswordKey;
                _context.SystemUsers.Update(userTemp);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<SystemUser> DeleteAsync(int id)
        {
            var userToUpdate = await GetAsync(id);
            if (userToUpdate != null)
            {
                _context.Remove(userToUpdate);
                await _context.SaveChangesAsync();
            }
            return userToUpdate;
        }

        public async Task<bool> AnyAsync(string userName, int? id)
        {
            if(id != null)
                return await _context.SystemUsers.AnyAsync(q => q.UserName == userName && q.Id != id);
            else
                return await _context.SystemUsers.AnyAsync(q => q.UserName == userName);
        }

        
    }
}
