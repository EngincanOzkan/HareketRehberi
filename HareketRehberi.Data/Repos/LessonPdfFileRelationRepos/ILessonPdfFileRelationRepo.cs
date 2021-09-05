using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonPdfFileRelationRepos
{
    public interface ILessonPdfFileRelationRepo
    {
        Task<IEnumerable<LessonPdfFileRelation>> GetAllAsync();
        Task<LessonPdfFileRelation> GetAsync(int id);
        Task<IEnumerable<LessonPdfFileRelation>> GetByLessonIdAsync(int lessonId);
        Task<LessonPdfFileRelation> CreateAsync(LessonPdfFileRelation lessonPdfFileRelation);
        Task<LessonPdfFileRelation> UpdateAsync(LessonPdfFileRelation lessonPdfFileRelation);
        Task<LessonPdfFileRelation> DeleteAsync(int id);
    }
}
