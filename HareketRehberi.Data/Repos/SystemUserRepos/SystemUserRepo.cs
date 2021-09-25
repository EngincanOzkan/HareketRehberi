using AutoMapper;
using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.SystemUserRepos
{
    public class SystemUserRepo : BaseRepo<SystemUser>, ISystemUserRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SystemUserRepo(DataContext context, IMapper mapper): base(context) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SystemUser> GetByUserNameAsync(string userName) {
            return await _context.SystemUsers.FirstOrDefaultAsync(q => q.UserName == userName);
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
