using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonPdfFileRelationBL
{
    public interface ILessonPdfFileRelationBL
    {
        Task<IEnumerable<LessonPdfFileRelation>> GetAll();
        Task<LessonPdfFileRelation> Get(int id);
        Task<IEnumerable<LessonPdfFileRelation>> GetByLessonId(int lessonId);
        Task<LessonPdfFileRelation> Create(LessonPdfFileRelation relation);
        Task<LessonPdfFileRelation> Update(LessonPdfFileRelation relation);
        Task<LessonPdfFileRelation> Delete(int id);
    }
}
