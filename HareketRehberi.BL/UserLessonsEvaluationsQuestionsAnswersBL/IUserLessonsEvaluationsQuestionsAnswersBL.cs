using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.UserLessonsEvaluationsQuestionsAnswersBL
{
    public interface IUserLessonsEvaluationsQuestionsAnswersBL
    {
        Task<IEnumerable<UserLessonsEvaluationsQuestionsAnswers>> GetAll();
        Task<UserLessonsEvaluationsQuestionsAnswers> Get(int id);
        Task<UserLessonsEvaluationsQuestionsAnswers> Create(UserLessonsEvaluationsQuestionsAnswers userLessonsEvaluationsQuestionsAnswers);
        Task<UserLessonsEvaluationsQuestionsAnswers> UpdateAnswer(int id, int answerId);
        Task<UserLessonsEvaluationsQuestionsAnswers> Update(UserLessonsEvaluationsQuestionsAnswers userLessonsEvaluationsQuestionsAnswers);
        Task<UserLessonsEvaluationsQuestionsAnswers> Delete(int id);
        Task<IEnumerable<StartEvaluationResponse>> StartEvaluation(StartEvaluationRequest startEvaluationRequest);
    }
}
