using HareketRehberi.BL.SystemUserBL;
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
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserBL _systemUserBL;

        public SystemUserController(ISystemUserBL systemUserBL)
        {
            _systemUserBL = systemUserBL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _systemUserBL.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _systemUserBL.Get(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SystemUserRequest user)
        {
            return Ok(await _systemUserBL.Create(user));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] SystemUserRequest user)
        {
            return Ok(await _systemUserBL.Update(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NotFound(await _systemUserBL.Delete(id));
        }
    }
}
