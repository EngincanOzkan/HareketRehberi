using HareketRehberi.BL.FileBL;
using HareketRehberi.BL.LessonSoundFileRelationBL;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundFileController : ControllerBase
    {
        private readonly FileBL _fileBL;
        private readonly ILessonSoundFileRelationBL _lessonSoundFileRelationBL;
        public SoundFileController(FileBL fileBL, ILessonSoundFileRelationBL lessonSoundFileRelationBL)
        {
            _fileBL = fileBL;
            _lessonSoundFileRelationBL = lessonSoundFileRelationBL;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<LessonSoundFileRelation> Upload([FromForm] UploadRequest request)
        {
            var result = await _fileBL.UploadSoundFile(Request.Form.Files[0], request.LessonId, (int)request.PageNumber);
            return result;
        }

        [HttpGet("download/{SoundId}")]
        public async Task<IActionResult> Download(int SoundId)
        {
            try
            {
                return await _fileBL.DownloadSoundFile(SoundId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("LessonFileInfo/{LessonId}")]
        public async Task<IEnumerable<LessonSoundFileRelation>> FileInfo(int LessonId)
        {
            return await _lessonSoundFileRelationBL.GetByLessonId(LessonId);
        }

        [HttpDelete("{SoundId}")]
        public async Task<LessonSoundFileRelation> Delete(int SoundId)
        {
            var result = await _lessonSoundFileRelationBL.Delete(SoundId);
            _fileBL.DeleteSoundFile(result);
            return result;
        }
    }
}
