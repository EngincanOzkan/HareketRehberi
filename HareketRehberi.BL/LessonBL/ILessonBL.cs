using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonBL
{
    public interface ILessonBL
    {
        Task<IEnumerable<Lesson>> GetAll();
        Task<Lesson> Get(int id);
        Task<IEnumerable<Lesson>> GetUserLessons(int userId);
        Task<Lesson> Create(LessonRequest lessonRequest);
        Task<Lesson> Update(LessonRequest lessonRequest);
        Task<Lesson> Delete(int id);
    }
}