using HareketRehberi.BL.LessonPdfFileRelationBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HareketRehberi.BL.FileBL
{
    public class FileBL
    {
        private readonly ILessonPdfFileRelationBL _lessonPdfFileRelationBL;
        private readonly string _pdfsFolder = Path.Combine("Resources", "PDFs");
        private readonly string _pdfsFolderFull;

        public FileBL(ILessonPdfFileRelationBL lessonPdfFileRelationBL)
        {
            _lessonPdfFileRelationBL = lessonPdfFileRelationBL;
            _pdfsFolderFull = Path.Combine(Directory.GetCurrentDirectory(), _pdfsFolder);
        }

        public async Task<bool> UploadPdfFile(IFormFile file, int lessonId) {
            Guid fileSaveName = Guid.NewGuid();
            try
            {
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var fileExtension = FileExtensions.pdf;
                    var strFileSaveName = $"{fileSaveName.ToString()}{fileExtension}";
                    var fullPath = Path.Combine(_pdfsFolderFull, strFileSaveName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    await cleanAndInsertPdfFile(lessonId, fileName, fileSaveName);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ($"Internal server error: {ex}");
            }
        }

        public async Task<PhysicalFileResult> DownloadPdfFile(int lessonId) {
            var files = await _lessonPdfFileRelationBL.GetByLessonId(lessonId);
            foreach (var file in files)
            {
                var strFileName = $"{file.FileGuid.ToString()}{FileExtensions.pdf}";
                var fullPath = Path.Combine(_pdfsFolderFull, strFileName);
                return new PhysicalFileResult(fullPath, "application/pdf");
            }
            return null;
        }

        public async Task<LessonPdfFileRelation> FileInfo(int lessonId)
        {
            var files = await _lessonPdfFileRelationBL.GetByLessonId(lessonId);
            foreach (var file in files)
            {
                return file;
            }
            return null;
        }

        private async Task cleanAndInsertPdfFile(int lessonId, string fileName, Guid fileGuid) {
            var files = await _lessonPdfFileRelationBL.GetByLessonId(lessonId);

            foreach (var file in files)
            {
                try
                {
                    var oldFileName = file.FileGuid.ToString();
                    var fileExtension = FileExtensions.pdf;
                    var strFileSaveName = $"{oldFileName}{ fileExtension}";
                    var fullPath = Path.Combine(_pdfsFolderFull, strFileSaveName);

                    await _lessonPdfFileRelationBL.Delete(file.Id);
                    File.Delete(fullPath);
                }
                catch { continue; }
            }

            await _lessonPdfFileRelationBL.Create(new LessonPdfFileRelation { 
                FileGuid = fileGuid,
                FileName = fileName,
                LessonId = lessonId
            });
        }
    }
}
