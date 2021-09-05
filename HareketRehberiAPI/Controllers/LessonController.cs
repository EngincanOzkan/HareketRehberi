using HareketRehberi.BL.LessonBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Role.Admin)]
    public class LessonController : ControllerBase
    {
        private readonly ILessonBL _lessonBL;

        public LessonController(ILessonBL lessonBL)
        {
            _lessonBL = lessonBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _lessonBL.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _lessonBL.Get(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LessonRequest lesson)
        {
            return Ok(await _lessonBL.Create(lesson));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] LessonRequest lesson)
        {
            return Ok(await _lessonBL.Update(lesson));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _lessonBL.Delete(id));
        }
    }
}
