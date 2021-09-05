using HareketRehberi.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonRepos
{
    public class LessonRepo : ILessonRepo
    {
        private readonly DataContext _context;

        public LessonRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetAllAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetAsync(int id)
        {
            return await _context.Lessons.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Lesson> CreateAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> UpdateAsync(Lesson lesson)
        {
            var lessonToUpdate = await this.GetAsync(lesson.Id);
            if (lessonToUpdate != null)
            {
                lessonToUpdate.LessonName = lesson.LessonName;
                _context.Lessons.Update(lessonToUpdate);
                await _context.SaveChangesAsync();
            }
            return lesson;
        }

        public async Task<Lesson> DeleteAsync(int id)
        {
            var lessonToDelete = await GetAsync(id);
            if (lessonToDelete != null)
            {
                _context.Lessons.Remove(lessonToDelete);
                await _context.SaveChangesAsync();
            }
            return lessonToDelete;
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
