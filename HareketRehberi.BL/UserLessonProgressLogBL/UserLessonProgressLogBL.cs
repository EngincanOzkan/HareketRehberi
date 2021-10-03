using HareketRehberi.Data.Repos.UserLessonProgressLogRepos;
using HareketRehberi.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.UserLessonProgressLogBL
{
    public class UserLessonProgressLogBL : IUserLessonProgressLogBL
    {
        private readonly IUserLessonProgressLogRepo _userLessonProgressLogRepo;

        public UserLessonProgressLogBL(IUserLessonProgressLogRepo userLessonProgressLogRepo)
        {
            _userLessonProgressLogRepo = userLessonProgressLogRepo;
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetAll()
        {
            var response = await _userLessonProgressLogRepo.GetAllAsync();
            return response;
        }

        public async Task<UserLessonProgressLog> Get(int id)
        {
            var response = await _userLessonProgressLogRepo.GetAsync(id);
            return response;
        }

        public async Task<UserLessonProgressLog> Create(UserLessonProgressLog userLessonProgressLog)
        {
            var response = await _userLessonProgressLogRepo.CreateAsync(userLessonProgressLog);
            return response;
        }

        public async Task<UserLessonProgressLog> Update(UserLessonProgressLog userLessonProgressLog)
        {
            var response = await _userLessonProgressLogRepo.UpdateAsync(userLessonProgressLog);
            return response;
        }

        public async Task<UserLessonProgressLog> Delete(int id)
        { 
            var response = await _userLessonProgressLogRepo.DeleteAsync(id);
            return response;
        }

        public async Task<UserLessonProgressLog> CreateStartLog(UserLessonProgressLog userLessonProgressLog)
        {
            var response = await _userLessonProgressLogRepo.CreateStartLog(userLessonProgressLog);
            return response;
        }

        public async Task<UserLessonProgressLog> CreateEndLog(UserLessonProgressLog userLessonProgressLog)
        {
            var response = await _userLessonProgressLogRepo.CreateEndLog(userLessonProgressLog);
            return response;
        }

        public async Task<UserLessonProgressLog> GetUserLessonLastStartLog(int userId, int lessonId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonLastStartLog(userId, lessonId);
            return response;
        }

        public async Task<UserLessonProgressLog> GetUserLessonLastEndLog(int userId, int lessonId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonLastStartLog(userId, lessonId);
            return response;
        }

        public async Task<UserLessonProgressLog> GetUserLessonEndLogByGuid(Guid operationIdentifier)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonEndLogByGuid(operationIdentifier);
            return response;
        }

        public async Task<UserLessonProgressLog> GetUserLessonStartLogByGuid(Guid operationIdentifier)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonStartLogByGuid(operationIdentifier);
            return response;
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonStartLogs(int userId, int lessonId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonStartLogs(userId, lessonId);
            return response;
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonEndLogs(int userId, int lessonId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonEndLogs(userId, lessonId);
            return response;
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsGeneral(int userId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonLogsGeneral(userId);
            return response;
        }

        public async Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsToday(int userId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonLogsToday(userId);
            return response;
        }
        public async Task<IEnumerable<object>> GetUserLessonLogsGeneralPre(int userId)
        {
            var response = await _userLessonProgressLogRepo.GetUserLessonLogsGeneralPre(userId);
            return response;
        }
    }
}
