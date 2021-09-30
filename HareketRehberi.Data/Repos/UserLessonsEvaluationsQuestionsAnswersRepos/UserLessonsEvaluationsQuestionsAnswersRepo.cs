using HareketRehberi.Domain.Models.Entities;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.UserLessonsEvaluationsQuestionsAnswersRepos
{
    public class UserLessonsEvaluationsQuestionsAnswersRepo : BaseRepo<UserLessonsEvaluationsQuestionsAnswers>, IUserLessonsEvaluationsQuestionsAnswersRepo
    {
        private readonly DataContext _context;
        public UserLessonsEvaluationsQuestionsAnswersRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserLessonsEvaluationsQuestionsAnswers> UpdateAnswer(int id, int answerId)
        {
            var entity = await GetAsync(id);
            entity.AnswerId = answerId;
            _context.UserLessonsEvaluationsQuestionsAnswersTable.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
