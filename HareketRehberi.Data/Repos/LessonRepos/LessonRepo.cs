using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
