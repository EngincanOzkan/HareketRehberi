using AutoMapper;
using HareketRehberi.BL.UserLessonsEvaluationsQuestionsAnswersBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLessonsEvaluationsQuestionsAnswersController : ControllerBase
    {
        private readonly IUserLessonsEvaluationsQuestionsAnswersBL _userLessonsEvaluationsQuestionsAnswersBL;
        private readonly IMapper _mapper;

        public UserLessonsEvaluationsQuestionsAnswersController(IUserLessonsEvaluationsQuestionsAnswersBL userLessonsEvaluationsQuestionsAnswersBL, IMapper mapper)
        {
            _userLessonsEvaluationsQuestionsAnswersBL = userLessonsEvaluationsQuestionsAnswersBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody]  UserLessonsEvaluationsQuestionsAnswersRequest userLessonsEvaluationsQuestionsAnswersRequest)
        {
            var userLessonsEvaluationsQuestionsAnswers = new UserLessonsEvaluationsQuestionsAnswers();
            _mapper.Map(userLessonsEvaluationsQuestionsAnswersRequest, userLessonsEvaluationsQuestionsAnswers);
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.Create(userLessonsEvaluationsQuestionsAnswers));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] UserLessonsEvaluationsQuestionsAnswersRequest userLessonsEvaluationsQuestionsAnswersRequest)
        {
            var userLessonsEvaluationsQuestionsAnswers = new UserLessonsEvaluationsQuestionsAnswers();
            _mapper.Map(userLessonsEvaluationsQuestionsAnswersRequest, userLessonsEvaluationsQuestionsAnswers);
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.Update(userLessonsEvaluationsQuestionsAnswers));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.Delete(id));
        }

        [HttpPatch("UpdateAnswer/{id}/{answerId}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> UpdateAnswer(int id, int answerId)
        {
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.UpdateAnswer(id, answerId));
        }

        [HttpPost("StartEvaluation")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> StartEvaluation([FromBody] StartEvaluationRequest startEvaluationRequest)
        {
            return Ok(await _userLessonsEvaluationsQuestionsAnswersBL.StartEvaluation(startEvaluationRequest));
        }
    }
}
