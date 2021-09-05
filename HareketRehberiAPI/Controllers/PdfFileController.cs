
using HareketRehberi.BL.FileBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Entities;
using HareketRehberi.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HareketRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfFileController : ControllerBase
    {
        private readonly FileBL _fileBL;

        public PdfFileController(FileBL fileBL)
        {
            _fileBL = fileBL;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload([FromForm] UploadRequest request)
        {
            try
            {
                var result = await _fileBL.UploadPdfFile(Request.Form.Files[0], request.LessonId);
                return result ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [Authorize(Roles = Role.User + "," + Role.Admin)]
        [HttpGet("download/{LessonId}")]
        public async Task<IActionResult> Download(int lessonId)
        {
            try
            {
               return await _fileBL.DownloadPdfFile(lessonId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("LessonFileInfo/{LessonId}")]
        public async Task<LessonPdfFileRelation> FileInfo(int lessonId)
        {
             return await _fileBL.PdfFileInfo(lessonId);
        }
    }
}
