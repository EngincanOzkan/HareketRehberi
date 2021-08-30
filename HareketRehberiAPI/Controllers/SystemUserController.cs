using AutoMapper;
using HareketRehberi.BL.SystemUserBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Role.Admin)]
    public class SystemUserController : ControllerBase
    {
        private readonly ISystemUserBL _systemUserBL;
        private readonly IMapper _mapper;

        public SystemUserController(ISystemUserBL systemUserBL, IMapper mapper)
        {
            _systemUserBL = systemUserBL;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SystemUserRequest user)
        {
            var userToCreate = new SystemUser();
            _mapper.Map(user, userToCreate);
            return Ok(await _systemUserBL.Create(userToCreate));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] SystemUserRequest user)
        {
            var userToUpdate = new SystemUser();
            _mapper.Map(user, userToUpdate);
            return Ok(await _systemUserBL.Update(userToUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NotFound(await _systemUserBL.Delete(id));
        }
    }
}
