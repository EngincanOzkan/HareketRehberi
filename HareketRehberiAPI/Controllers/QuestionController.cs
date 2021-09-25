using AutoMapper;
using HareketRehberi.BL.QuestionBL;
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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionBL _questionBL;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionBL questionBL, IMapper mapper) {
            _questionBL = questionBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _questionBL.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _questionBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] QuestionRequest questionRequest)
        {
            var question = new Question();
            _mapper.Map(questionRequest, question);
            return Ok(await _questionBL.Create(question));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] QuestionRequest questionRequest)
        {
            var question = new Question();
            _mapper.Map(questionRequest, question);
            return Ok(await _questionBL.Update(question));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _questionBL.Delete(id));
        }
    }
}
