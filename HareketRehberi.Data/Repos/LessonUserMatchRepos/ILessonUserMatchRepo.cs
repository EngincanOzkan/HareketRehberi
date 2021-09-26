using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonUserMatchRepos
{
    public interface ILessonUserMatchRepo : IBaseRepo<LessonUserMatch>
    {
        Task DeleteByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonUserMatch>> GetByUserIdAsync(int userId);
        Task<IEnumerable<LessonUserMatch>> GetByLessonIdAsync(int lessonId);
    }
}
