using HareketRehberi.Domain.Models.Entities;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonEvaluationMatchRepos
{
    public interface ILessonEvaluationMatchRepo : IBaseRepo<LessonEvaluationMatch>
    {
        Task<LessonEvaluationMatch> DeleteByLessonIdAsync(int lessonId);
    }
}
