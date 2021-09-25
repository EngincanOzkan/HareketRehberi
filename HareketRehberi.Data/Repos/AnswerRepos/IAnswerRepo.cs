using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.AnswerRepos
{
    public interface IAnswerRepo : IBaseRepo<Answer>
    {
        Task<IEnumerable<Answer>> GetByQuestionId(int questionId);
    }
}
