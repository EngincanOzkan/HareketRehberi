using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class LessonSoundFileRelation : BaseEntity
    {
        public int LessonId { get; set; }
        public int PageNumber { get; set; }
        public string FileName { get; set; }
        public Guid FileGuid { get; set; }

        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
    }
}
