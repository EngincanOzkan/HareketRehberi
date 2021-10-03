using HareketRehberi.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.UserLessonProgressLogRepos
{
    public interface IUserLessonProgressLogRepo : IBaseRepo<UserLessonProgressLog>
    {
        Task<UserLessonProgressLog> CreateStartLog(UserLessonProgressLog userLessonProgressLog);
        Task<UserLessonProgressLog> CreateEndLog(UserLessonProgressLog userLessonProgressLog);
        Task<UserLessonProgressLog> GetUserLessonLastStartLog(int userId, int lessonId);
        Task<UserLessonProgressLog> GetUserLessonLastEndLog(int userId, int lessonId);
        Task<UserLessonProgressLog> GetUserLessonEndLogByGuid(Guid operationIdentifier);
        Task<UserLessonProgressLog> GetUserLessonStartLogByGuid(Guid operationIdentifier);
        Task<IEnumerable<UserLessonProgressLog>> GetUserLessonStartLogs(int userId, int lessonId);
        Task<IEnumerable<UserLessonProgressLog>> GetUserLessonEndLogs(int userId, int lessonId);
        Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsGeneral(int userId);
        Task<IEnumerable<UserLessonProgressLog>> GetUserLessonLogsToday(int userId);
    }
}
