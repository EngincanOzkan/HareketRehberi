using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.UserLessonProgressLogRepos
{
    public class UserLessonProgressLogRepo : BaseRepo<UserLessonProgressLog>, IUserLessonProgressLogRepo
    {
        private readonly DataContext _context;
        public UserLessonProgressLogRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserLessonProgressLog> CreateStartLog(UserLessonProgressLog userLessonProgressLog)
        {
            userLessonProgressLog.OperationIdentifier = Guid.NewGuid();
            userLessonProgressLog.OperationTime = DateTime.Now;
            userLessonProgressLog.IsStart = true;
            await _context.UserLessonProgressLogs.AddAsync(userLessonProgressLog);
            await _context.SaveChangesAsync();
            return userLessonProgressLog;
        }

        public async Task<UserLessonProgressLog> CreateEndLog(UserLessonProgressLog userLessonProgressLog)
        {
            userLessonProgressLog.OperationTime = DateTime.Now;
            userLessonProgressLog.IsStart = false;
            await _context.UserLessonProgressLogs.AddAsync(userLessonProgressLog);
            await _context.SaveChangesAsync();
            return userLessonProgressLog;
        }

        public async Task<UserLessonProgressLog> GetUserLessonLastStartLog(int userId, int lessonId) 
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == true).OrderByDescending(q => q.Id).FirstOrDefaultAsync();
        }

        public async Task<UserLessonProgressLog> GetUserLessonLastEndLog(int userId, int lessonId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == false).OrderByDescending(q => q.Id).FirstOrDefaultAsync();
        }

        public async Task<UserLessonProgressLog> GetUserLessonEndLogByGuid(Guid operationIdentifier)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.OperationIdentifier == operationIdentifier && q.IsStart == false).FirstOrDefaultAsync();
        }

        public async Task<UserLessonProgressLog> GetUserLessonStartLogByGuid(Guid operationIdentifier)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.OperationIdentifier == operationIdentifier && q.IsStart == true).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonStartLogs(int userId, int lessonId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == true).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonEndLogs(int userId, int lessonId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.LessonId == lessonId && q.IsStart == false).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsGeneral(int userId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.IsStart == false).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsToday(int userId)
        {
            return await _context.UserLessonProgressLogs.Where(q => q.UserId == userId && q.IsStart == false && q.OperationTime.Date == DateTime.Today).ToListAsync();
        }
    }
}
