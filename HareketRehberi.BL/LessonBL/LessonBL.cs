using HareketRehberi.Data.Repos.LessonRepos;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.LessonBL
{
    public class LessonBL : ILessonBL
    {
        private readonly ILessonRepo _lessonRepo;

        public LessonBL(ILessonRepo lessonRepo)
        {
            _lessonRepo = lessonRepo;
        }

        public async Task<Lesson> Create(LessonRequest lessonRequest)
        {
            if (await IsLessonExists(lessonRequest.LessonName, null)) throw new System.Exception("Eğitim adı daha önceden eklenmiş!!!");

            var lesson = new Lesson
            {
                LessonName = lessonRequest.LessonName,
                ProgressiveRelaxationExercise = lessonRequest.ProgressiveRelaxationExercise
            };

            var lessonCrearted = await _lessonRepo.CreateAsync(lesson);
            return lessonCrearted;
        }

        public async Task<Lesson> Delete(int id)
        {
            var lesson = await _lessonRepo.DeleteAsync(id);
            return lesson;
        }

        public async Task<Lesson> Get(int id)
        {
            var lesson = await _lessonRepo.GetAsync(id);
            return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetUserLessons(int userId)
        {
            var lesson = await _lessonRepo.GetUserLessons(userId);
            return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetUsersProgressiveRelaxationExercises(int userId)
        {
            var lesson = await _lessonRepo.GetUsersProgressiveRelaxationExercises(userId);
            return lesson;
        }
        

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            var lesson = await _lessonRepo.GetAllAsync();
            return lesson;
        }

        public async Task<Lesson> Update(LessonRequest lessonRequest)
        {
            if (await IsLessonExists(lessonRequest.LessonName, lessonRequest.Id) || lessonRequest.Id == null || lessonRequest.Id == 0) throw new System.Exception("Eğitim adı daha önceden eklenmiş!!!");

            var lesson = new Lesson
            {
                Id = (int)lessonRequest.Id,
                LessonName = lessonRequest.LessonName,
                ProgressiveRelaxationExercise = lessonRequest.ProgressiveRelaxationExercise
            };

            var lessonUpdated = await _lessonRepo.UpdateAsync(lesson);
            return lessonUpdated;
        }

        private async Task<bool> IsLessonExists(string lessonName, int? id)
        {
            return await _lessonRepo.AnyAsync(lessonName, id);
        }
    }
}
