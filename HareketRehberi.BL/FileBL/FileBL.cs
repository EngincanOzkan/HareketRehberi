using HareketRehberi.BL.LessonPdfFileRelationBL;
using HareketRehberi.BL.LessonSoundFileRelationBL;
using HareketRehberi.Domain.Consts;
using HareketRehberi.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HareketRehberi.BL.FileBL
{
    public class FileBL
    {
        private readonly ILessonPdfFileRelationBL _lessonPdfFileRelationBL;
        private readonly ILessonSoundFileRelationBL _lessonSoundFileRelationBL;

        private readonly string _pdfsFolder = Path.Combine("Resources", "PDFs");
        private readonly string _pdfsFolderFull;


        private readonly string _soundsFolder = Path.Combine("Resources", "Sounds");
        private readonly string _soundsFolderFull;
        public FileBL(
              ILessonPdfFileRelationBL lessonPdfFileRelationBL
            , ILessonSoundFileRelationBL lessonSoundFileRelationBL
        )
        {
            _lessonPdfFileRelationBL = lessonPdfFileRelationBL;
            _lessonSoundFileRelationBL = lessonSoundFileRelationBL;

            _pdfsFolderFull = Path.Combine(Directory.GetCurrentDirectory(), _pdfsFolder);
            _soundsFolderFull = Path.Combine(Directory.GetCurrentDirectory(), _soundsFolder);
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

        public async Task<LessonPdfFileRelation> PdfFileInfo(int lessonId)
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

        public async Task<LessonSoundFileRelation> UploadSoundFile(IFormFile file, int lessonId, int pageNumber)
        {
            Guid fileSaveName = Guid.NewGuid();
            try
            {
                if (file.Length > 0)
                {
                    var fileName = file.FileName;
                    var fileExtension = FileExtensions.mp3;
                    var strFileSaveName = $"{fileSaveName.ToString()}{fileExtension}";
                    var fullPath = Path.Combine(_soundsFolderFull, strFileSaveName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    if((await _lessonSoundFileRelationBL.GetByPageNumber(pageNumber, lessonId)).Any()) throw new Exception("Sayfa numarasına önceden tanımlama yapılmış");

                    var response = await _lessonSoundFileRelationBL.Create(new LessonSoundFileRelation
                    {
                        FileGuid = fileSaveName,
                        FileName = fileName,
                        LessonId = lessonId,
                        PageNumber = pageNumber
                    });

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new($"Internal server error: {ex}");
            }
        }

        public async Task<PhysicalFileResult> DownloadSoundFile(int SoundId)
        {
            var file = await _lessonSoundFileRelationBL.Get(SoundId);
            var strFileName = $"{file.FileGuid.ToString()}{FileExtensions.mp3}";
            var fullPath = Path.Combine(_soundsFolderFull, strFileName);
            return new PhysicalFileResult(fullPath, "audio/mpeg");
        }

        public async Task<PhysicalFileResult> DownloadSoundFileByLessonAndPage(int lessonId, int pageNumber)
        {
            var file = await _lessonSoundFileRelationBL.Get(lessonId, pageNumber);
            var strFileName = $"{file.FileGuid.ToString()}{FileExtensions.mp3}";
            var fullPath = Path.Combine(_soundsFolderFull, strFileName);
            return new PhysicalFileResult(fullPath, "audio/mpeg");
        }

        public void DeleteSoundFile(LessonSoundFileRelation file)
        {
            var strFileName = $"{file.FileGuid.ToString()}{FileExtensions.mp3}";
            var fullPath = Path.Combine(_soundsFolderFull, strFileName);
            File.Delete(fullPath);
        }
    }
}
