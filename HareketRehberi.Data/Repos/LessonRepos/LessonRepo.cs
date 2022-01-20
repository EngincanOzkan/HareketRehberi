using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonRepos
{
    public class LessonRepo : BaseRepo<Lesson>, ILessonRepo
    {
        private readonly DataContext _context;

        public LessonRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(string lessonName, int? id)
        {
            if (id != null)
                return await _context.Lessons.AnyAsync(q => q.LessonName == lessonName && q.Id != id);
            else
                return await _context.Lessons.AnyAsync(q => q.LessonName == lessonName);
        }

        public async Task<IEnumerable<Lesson>> GetUserLessons(int userId) {
            var matches = await _context.LessonUserMatches.Where(q => q.UserId == userId).Select(q => q.LessonId).ToListAsync();
            return await _context.Lessons.Where(q => matches.Contains(q.Id) && q.ProgressiveRelaxationExercise == false).OrderBy(q => q.LessonName).ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetUsersProgressiveRelaxationExercises(int userId)
        {
            var matches = await _context.LessonUserMatches.Where(q => q.UserId == userId).Select(q => q.LessonId).ToListAsync();
            return await _context.Lessons.Where(q => matches.Contains(q.Id) && q.ProgressiveRelaxationExercise == true).ToListAsync();
        }
    }
}
