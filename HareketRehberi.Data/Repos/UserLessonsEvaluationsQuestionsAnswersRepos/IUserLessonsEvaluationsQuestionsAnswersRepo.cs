using HareketRehberi.Domain.Models.Entities;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.UserLessonsEvaluationsQuestionsAnswersRepos
{
    public interface IUserLessonsEvaluationsQuestionsAnswersRepo : IBaseRepo<UserLessonsEvaluationsQuestionsAnswers>
    {
        Task<UserLessonsEvaluationsQuestionsAnswers> UpdateAnswer(int id, int answerId);
    }
}
