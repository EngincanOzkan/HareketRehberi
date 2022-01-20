using HareketRehberi.BL.EvaluationBL;
using HareketRehberi.BL.LessonBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonBL _lessonBL;
        private readonly IEvaluationBL _evaluationBL;
        private readonly ILogger<LessonController> _logger;

        public LessonController(ILessonBL lessonBL, IEvaluationBL evaluationBL, ILogger<LessonController> logger)
        {
            _lessonBL = lessonBL;
            _evaluationBL = evaluationBL;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll() {
            return Ok(await _lessonBL.GetAll());
        }

        [HttpGet("GetUsersLessons/{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUsersLessons(int id)
        {
            return Ok(await _lessonBL.GetUserLessons(id));
        }

        [HttpGet("GetUsersProgressiveRelaxationExercises/{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUsersProgressiveRelaxationExercises(int id)
        {
            return Ok(await _lessonBL.GetUsersProgressiveRelaxationExercises(id));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _lessonBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] LessonRequest lesson)
        {
            _logger.LogError(lesson.LessonName);
            return Ok(await _lessonBL.Create(lesson));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] LessonRequest lesson)
        {
            _logger.LogError(lesson.LessonName);
            return Ok(await _lessonBL.Update(lesson));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _lessonBL.Delete(id));
        }

        [HttpGet("{lessonId}/evaluations")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetEvaluationsByLessonId(int lessonId)
        {
            return Ok(await _evaluationBL.GetEvaluationsByLessonId(lessonId));
        }
    }
}
