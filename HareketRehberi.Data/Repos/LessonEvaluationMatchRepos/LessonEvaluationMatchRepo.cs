using HareketRehberi.Domain.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonEvaluationMatchRepos
{
    public class LessonEvaluationMatchRepo : BaseRepo<LessonEvaluationMatch>, ILessonEvaluationMatchRepo
    {
        private readonly DataContext _context;
        public LessonEvaluationMatchRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LessonEvaluationMatch> DeleteByLessonIdAsync(int lessonId)
        {
            var entityToDelete = _context.LessonEvaluationMatches.Where(q => q.LessonId == lessonId).FirstOrDefault();
            if (entityToDelete != null)
            {
                _context.LessonEvaluationMatches.Remove(entityToDelete);
                await _context.SaveChangesAsync();
            }
            return entityToDelete;
        }
    }
}
