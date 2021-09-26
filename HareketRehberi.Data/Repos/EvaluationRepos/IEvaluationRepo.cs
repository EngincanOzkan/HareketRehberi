using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.EvaluationRepos
{
    public interface IEvaluationRepo : IBaseRepo<Evaluation>
    {
        Task<bool> AnyAsync(string evaluationName, int? id);
        Task<IEnumerable<Evaluation>> GetEvaluationsByLessonId(int lessonId);
    }
}
