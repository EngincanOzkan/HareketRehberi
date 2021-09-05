using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonRepos
{
    public interface ILessonRepo
    {
        Task<IEnumerable<Lesson>> GetAllAsync();
        Task<Lesson> GetAsync(int id);
        Task<Lesson> CreateAsync(Lesson lesson);
        Task<Lesson> UpdateAsync(Lesson lesson);
        Task<Lesson> DeleteAsync(int id);
        Task<bool> AnyAsync(string lessonName, int? id);
    }
}
