using AutoMapper;
using HareketRehberi.BL.UserLessonProgressLogBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLessonProgressLogController : ControllerBase
    {
        private readonly IUserLessonProgressLogBL _userLessonProgressLogBL;
        private readonly IMapper _mapper;

        public UserLessonProgressLogController(IUserLessonProgressLogBL userLessonProgressLogBL, IMapper mapper)
        {
            _userLessonProgressLogBL = userLessonProgressLogBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userLessonProgressLogBL.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userLessonProgressLogBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] UserLessonProgressLogRequest userLessonProgressLogRequest)
        {
            var userLessonProgressLog = new UserLessonProgressLog();
            _mapper.Map(userLessonProgressLogRequest, userLessonProgressLog);
            return Ok(await _userLessonProgressLogBL.Create(userLessonProgressLog));
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] UserLessonProgressLogRequest userLessonProgressLogRequest)
        {
            var userLessonProgressLog = new UserLessonProgressLog();
            _mapper.Map(userLessonProgressLogRequest, userLessonProgressLog);
            return Ok(await _userLessonProgressLogBL.Update(userLessonProgressLog));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userLessonProgressLogBL.Delete(id));
        }

        [HttpPost("CreateStartLog")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> CreateStartLog([FromBody] UserLessonProgressLogRequest userLessonProgressLogRequest)
        {
            var userLessonProgressLog = new UserLessonProgressLog();
            _mapper.Map(userLessonProgressLogRequest, userLessonProgressLog);
            return Ok(await _userLessonProgressLogBL.CreateStartLog(userLessonProgressLog));
        }

        [HttpPost("CreateEndLog")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> CreateEndLog([FromBody] UserLessonProgressLogRequest userLessonProgressLogRequest)
        {
            var userLessonProgressLog = new UserLessonProgressLog();
            _mapper.Map(userLessonProgressLogRequest, userLessonProgressLog);
            return Ok(await _userLessonProgressLogBL.CreateEndLog(userLessonProgressLog));
        }

        [HttpGet("GetUserLessonLastStartLog/{userid}/{lessonid}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonLastStartLog(int userId, int lessonId)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonLastStartLog(userId, lessonId));
        }

        [HttpGet("GetUserLessonLastEndLog/{userid}/{lessonid}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult>  GetUserLessonLastEndLog(int userId, int lessonId)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonLastEndLog(userId, lessonId));
        }

        [HttpGet("GetUserLessonEndLogByGuid/{operationIdentifier}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonEndLogByGuid(Guid operationIdentifier)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonEndLogByGuid(operationIdentifier));
        }

        [HttpGet("GetUserLessonStartLogByGuid/{operationIdentifier}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonStartLogByGuid(Guid operationIdentifier)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonStartLogByGuid(operationIdentifier));
        }

        [HttpGet("GetUserLessonStartLogs/{userid}/{lessonid}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonStartLogs(int userId, int lessonId)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonStartLogs(userId, lessonId));
        }

        [HttpGet("GetUserLessonEndLogs/{userid}/{lessonid}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonEndLogs(int userId, int lessonId)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonEndLogs(userId, lessonId));
        }

        [HttpGet("GetUserLessonLogsGeneral/{userid}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonLogsGeneral(int userId)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonLogsGeneral(userId));
        }


        [HttpGet("GetUserLessonLogsToday/{userid}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetUserLessonLogsToday(int userId)
        {
            return Ok(await _userLessonProgressLogBL.GetUserLessonLogsToday(userId));
        }
    }
}
