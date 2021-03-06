using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonRepos
{
    public interface ILessonRepo : IBaseRepo<Lesson>
    {
        Task<bool> AnyAsync(string lessonName, int? id);
        Task<IEnumerable<Lesson>> GetUserLessons(int userId);
        Task<IEnumerable<Lesson>> GetUsersProgressiveRelaxationExercises(int userId);
        
    }
}
