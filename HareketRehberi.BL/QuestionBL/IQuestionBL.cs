using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.QuestionBL
{
    public interface IQuestionBL
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question> Get(int id);
        Task<IEnumerable<Question>> GetByEvaluationId(int evaluationId);
        Task<Question> Create(Question question);
        Task<Question> Update(Question question);
        Task<Question> Delete(int id);
    }
}
