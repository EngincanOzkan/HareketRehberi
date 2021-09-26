using AutoMapper;
using HareketRehberi.BL.LessonUserMatchBL;
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
    public class LessonUserMatchController : ControllerBase
    {
        private readonly ILessonUserMatchBL _lessonUserMatchBL;
        private readonly IMapper _mapper;

        public LessonUserMatchController(ILessonUserMatchBL lessonUserMatchBL, IMapper mapper)
        {
            _lessonUserMatchBL = lessonUserMatchBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _lessonUserMatchBL.GetAll());
        }

        [HttpGet("GetByLessonId/{lessonId}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetByLessonId(int lessonId)
        {
            return Ok(await _lessonUserMatchBL.GetByLessonId(lessonId));
        }

        [HttpGet("GetByUserId/{userId}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return Ok(await _lessonUserMatchBL.GetByUserId(userId));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _lessonUserMatchBL.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Create([FromBody] LessonUserMatchRequest lessonUserMatchRequest)
        {
            await _lessonUserMatchBL.DeleteByLessonId(lessonUserMatchRequest.LessonId);
            if (lessonUserMatchRequest.UserId != null)
            {
                var lessonUserMatch = new LessonUserMatch();
                _mapper.Map(lessonUserMatchRequest, lessonUserMatch);
                return Ok(await _lessonUserMatchBL.Create(lessonUserMatch));
            }
            else {
                foreach (var item in lessonUserMatchRequest.UserIds)
                {
                    var lessonUserMatch = new LessonUserMatch();
                    _mapper.Map(lessonUserMatchRequest, lessonUserMatch);
                    lessonUserMatch.UserId = item;
                    await _lessonUserMatchBL.Create(lessonUserMatch);
                }
                return Ok();
            }
        }

        [HttpPatch]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update([FromBody] LessonUserMatchRequest lessonUserMatchRequest)
        {
            var lessonUserMatch = new LessonUserMatch();
            _mapper.Map(lessonUserMatchRequest, lessonUserMatch);
            return Ok(await _lessonUserMatchBL.Update(lessonUserMatch));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _lessonUserMatchBL.Delete(id));
        }

        [HttpDelete("DeleteLessonsUserMatches/{lessonId}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteLessonsUserMatches(int lessonId)
        {
            await _lessonUserMatchBL.DeleteByLessonId(lessonId);
            return Ok();
        }
    }
}
