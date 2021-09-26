using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonUserMatchRepos
{
    public class LessonUserMatchRepo : BaseRepo<LessonUserMatch>, ILessonUserMatchRepo
    {
        private readonly DataContext _context;
        public LessonUserMatchRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteByLessonIdAsync(int lessonId)
        {
            var entitiesToDelete = await _context.LessonUserMatches.Where(q => q.LessonId == lessonId).ToListAsync();
            if (entitiesToDelete != null)
            {
                _context.LessonUserMatches.RemoveRange(entitiesToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LessonUserMatch>> GetByLessonIdAsync(int lessonId)
        {
            return await _context.LessonUserMatches.Where(q => q.LessonId == lessonId).ToListAsync();
        }

        public async Task<IEnumerable<LessonUserMatch>> GetByUserIdAsync(int userId)
        {
            return await _context.LessonUserMatches.Where(q => q.UserId == userId).ToListAsync();
        }
    }
}
