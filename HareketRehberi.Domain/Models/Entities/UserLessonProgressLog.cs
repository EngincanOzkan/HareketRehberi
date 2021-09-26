using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class UserLessonProgressLog : BaseEntity
    {
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public bool? IsStart { get; set; } //false is end
        public DateTime OperationTime { get; set; }
        public Guid OperationIdentifier { get; set; } // start log and end log must be same
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
        [ForeignKey("UserId")]
        public SystemUser User { get; set; }
    }
}
