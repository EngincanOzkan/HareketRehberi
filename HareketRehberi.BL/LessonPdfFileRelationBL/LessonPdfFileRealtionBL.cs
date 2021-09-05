using HareketRehberi.Data.Repos.LessonPdfFileRelationRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonPdfFileRelationBL
{
    public class LessonPdfFileRelationBL : ILessonPdfFileRelationBL
    {
        private readonly ILessonPdfFileRelationRepo _lessonPdfFileRelationRepo;

        public LessonPdfFileRelationBL(ILessonPdfFileRelationRepo lessonPdfFileRelationRepo)
        {
            _lessonPdfFileRelationRepo = lessonPdfFileRelationRepo;
        }

        public async Task<IEnumerable<LessonPdfFileRelation>> GetAll()
        {
            var relations = await _lessonPdfFileRelationRepo.GetAllAsync();
            return relations;
        }

        public async Task<LessonPdfFileRelation> Get(int id)
        {
            var relation = await _lessonPdfFileRelationRepo.GetAsync(id);
            return relation;
        }
        public async Task<IEnumerable<LessonPdfFileRelation>> GetByLessonId(int lessonId) {
            var relation = await _lessonPdfFileRelationRepo.GetByLessonIdAsync(lessonId);
            return relation;
        }

        public async Task<LessonPdfFileRelation> Create(LessonPdfFileRelation relation)
        {
            var createdRelation = await _lessonPdfFileRelationRepo.CreateAsync(relation);
            return createdRelation;
        }

        public async Task<LessonPdfFileRelation> Update(LessonPdfFileRelation relation)
        {
            var updatedRelation = await _lessonPdfFileRelationRepo.UpdateAsync(relation);
            return updatedRelation;
        }

        public async Task<LessonPdfFileRelation> Delete(int id)
        {
            var deletedRelation = await _lessonPdfFileRelationRepo.DeleteAsync(id);
            return deletedRelation;
        }
    }
}
