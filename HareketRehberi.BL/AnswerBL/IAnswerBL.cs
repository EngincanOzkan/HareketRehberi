using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.AnswerBL
{
    public interface IAnswerBL
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> Get(int id);
        Task<IEnumerable<Answer>> GetByQuestionId(int questionId);
        Task<Answer> Create(Answer question);
        Task<Answer> Update(Answer question);
        Task<Answer> Delete(int id);
    }
}
