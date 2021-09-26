using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonEvaluationMatchBL
{
    public interface ILessonEvaluationMatchBL
    {
        Task<IEnumerable<LessonEvaluationMatch>> GetAll();
        Task<LessonEvaluationMatch> Get(int id);
        Task<LessonEvaluationMatch> Create(LessonEvaluationMatch lessonEvaluationMatch);
        Task<LessonEvaluationMatch> Update(LessonEvaluationMatch lessonEvaluationMatch);
        Task<LessonEvaluationMatch> Delete(int id);
        Task<LessonEvaluationMatch> DeleteByLessonId(int lessonId);
    }
}
