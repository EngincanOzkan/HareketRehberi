using HareketRehberi.Data.Repos.QuestionRepos;
using HareketRehberi.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberi.BL.QuestionBL
{
    public class QuestionBL : IQuestionBL
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionBL(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            var response = await _questionRepo.GetAllAsync();
            return response;
        }

        public async Task<Question> Get(int id)
        {
            var response = await _questionRepo.GetAsync(id);
            return response;
        }
        public async Task<IEnumerable<Question>> GetByEvaluationId(int id)
        {
            var response = await _questionRepo.GetByEvaluationId(id);
            return response;
        }

        public async Task<Question> Create(Question question)
        {
            var response = await _questionRepo.CreateAsync(question);
            return response;
        }

        public async Task<Question> Update(Question question)
        {
            var response = await _questionRepo.UpdateAsync(question);
            return response;
        }

        public async Task<Question> Delete(int id)
        {
            var response = await _questionRepo.DeleteAsync(id);
            return response;
        }
    }
}
