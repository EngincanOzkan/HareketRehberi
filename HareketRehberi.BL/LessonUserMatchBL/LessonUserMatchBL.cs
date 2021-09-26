using HareketRehberi.Data.Repos.LessonUserMatchRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonUserMatchBL
{
    public class LessonUserMatchBL : ILessonUserMatchBL
    {
        private readonly ILessonUserMatchRepo _lessonUserMatchRepo;

        public LessonUserMatchBL(ILessonUserMatchRepo lessonUserMatchRepo)
        {
            _lessonUserMatchRepo = lessonUserMatchRepo;
        }

        public async Task<IEnumerable<LessonUserMatch>> GetAll()
        {
            var response = await _lessonUserMatchRepo.GetAllAsync();
            return response;
        }

        public async Task<LessonUserMatch> Get(int id)
        {
            var response = await _lessonUserMatchRepo.GetAsync(id);
            return response;
        }

        public async Task<IEnumerable<LessonUserMatch>> GetByUserId(int userId)
        {
            var response = await _lessonUserMatchRepo.GetByUserIdAsync(userId);
            return response;
        }

        public async Task<IEnumerable<LessonUserMatch>> GetByLessonId(int lessonId)
        {
            var response = await _lessonUserMatchRepo.GetByLessonIdAsync(lessonId);
            return response;
        }

        public async Task<LessonUserMatch> Create(LessonUserMatch lessonUserMatch)
        {
            var response = await _lessonUserMatchRepo.CreateAsync(lessonUserMatch);
            return response;
        }

        public async Task<LessonUserMatch> Update(LessonUserMatch lessonEvaluationMatch)
        {
            var response = await _lessonUserMatchRepo.UpdateAsync(lessonEvaluationMatch);
            return response;
        }

        public async Task<LessonUserMatch> Delete(int id)
        {
            var response = await _lessonUserMatchRepo.DeleteAsync(id);
            return response;
        }

        public async Task DeleteByLessonId(int lessonId)
        {
            await _lessonUserMatchRepo.DeleteByLessonIdAsync(lessonId);
        }
    }
}
