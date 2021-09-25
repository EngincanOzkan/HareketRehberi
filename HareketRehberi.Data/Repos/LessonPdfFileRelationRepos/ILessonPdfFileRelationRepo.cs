using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.Data.Repos.LessonPdfFileRelationRepos
{
    public interface ILessonPdfFileRelationRepo : IBaseRepo<LessonPdfFileRelation>
    {
        Task<IEnumerable<LessonPdfFileRelation>> GetByLessonIdAsync(int lessonId);
    }
}
