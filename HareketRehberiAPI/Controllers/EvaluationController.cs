using HareketRehberi.BL.EvaluationBL;
using HareketRehberi.BL.QuestionBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private readonly IQuestionBL _questionBL;
        private readonly IEvaluationBL _evaluationBL;

        public EvaluationController(IEvaluationBL evaluationBL, IQuestionBL questionBL)
        {
            _evaluationBL = evaluationBL;
            _questionBL = questionBL;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _evaluationBL.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _evaluationBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] EvaluationRequest evaluationRequest)
        {
            return Ok(await _evaluationBL.Create(evaluationRequest));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] EvaluationRequest evaluationRequest)
        {
            return Ok(await _evaluationBL.Update(evaluationRequest));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _evaluationBL.Delete(id));
        }

        [HttpGet("{evaluationId}/questions")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetQuestionsByEvaluationId(int evaluationId)
        {
            return Ok(await _questionBL.GetByEvaluationId(evaluationId));
        }
    }
}
