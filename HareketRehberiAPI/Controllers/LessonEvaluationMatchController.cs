using AutoMapper;
using HareketRehberi.BL.LessonEvaluationMatchBL;
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
    public class LessonEvaluationMatchController : ControllerBase
    {
        private readonly ILessonEvaluationMatchBL _lessonEvaluationMatchBL;
        private readonly IMapper _mapper;

        public LessonEvaluationMatchController(ILessonEvaluationMatchBL lessonEvaluationMatchBL, IMapper mapper)
        {
            _lessonEvaluationMatchBL = lessonEvaluationMatchBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _lessonEvaluationMatchBL.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _lessonEvaluationMatchBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] LessonEvaluationMatchRequest lessonEvaluationMatchRequest)
        {
            await _lessonEvaluationMatchBL.DeleteByLessonId(lessonEvaluationMatchRequest.LessonId);
            var lessonEvaluationMatch = new LessonEvaluationMatch();
            _mapper.Map(lessonEvaluationMatchRequest, lessonEvaluationMatch);
            return Ok(await _lessonEvaluationMatchBL.Create(lessonEvaluationMatch));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] LessonEvaluationMatchRequest lessonEvaluationMatchRequest)
        {
            var lessonEvaluationMatch = new LessonEvaluationMatch();
            _mapper.Map(lessonEvaluationMatchRequest, lessonEvaluationMatch);
            return Ok(await _lessonEvaluationMatchBL.Update(lessonEvaluationMatch));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _lessonEvaluationMatchBL.Delete(id));
        }

        [HttpDelete("DeleteLessonsEvaluation/{lessonId}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteLessonsEvaluation(int lessonId)
        {
            return Ok(await _lessonEvaluationMatchBL.DeleteByLessonId(lessonId));
        }
    }
}
