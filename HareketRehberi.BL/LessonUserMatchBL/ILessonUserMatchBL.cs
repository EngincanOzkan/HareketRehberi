using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonUserMatchBL
{
    public interface ILessonUserMatchBL
    {
        Task<IEnumerable<LessonUserMatch>> GetAll();
        Task<LessonUserMatch> Get(int id);
        Task<LessonUserMatch> Create(LessonUserMatch lessonUserMatch);
        Task<LessonUserMatch> Update(LessonUserMatch lessonUserMatch);
        Task<LessonUserMatch> Delete(int id);
        Task DeleteByLessonId(int lessonId);
        Task<IEnumerable<LessonUserMatch>> GetByUserId(int userId);
        Task<IEnumerable<LessonUserMatch>> GetByLessonId(int lessonId);
    }
}
