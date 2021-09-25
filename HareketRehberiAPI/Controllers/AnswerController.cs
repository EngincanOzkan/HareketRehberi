using AutoMapper;
using HareketRehberi.BL.AnswerBL;
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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerBL _answerBL;
        private readonly IMapper _mapper;

        public AnswerController(IAnswerBL answerBL, IMapper mapper)
        {
            _answerBL = answerBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _answerBL.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _answerBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] AnswerRequest answerRequest)
        {
            var answer = new Answer();
            _mapper.Map(answerRequest, answer);
            return Ok(await _answerBL.Create(answer));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] AnswerRequest answerRequest)
        {
            var answer = new Answer();
            _mapper.Map(answerRequest, answer);
            return Ok(await _answerBL.Update(answer));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _answerBL.Delete(id));
        }
    }
}
