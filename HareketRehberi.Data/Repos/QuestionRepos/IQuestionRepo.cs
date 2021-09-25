using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.QuestionRepos
{
    public interface IQuestionRepo : IBaseRepo<Question>
    {
        Task<IEnumerable<Question>> GetByEvaluationId(int evaluationId);
    }
}
