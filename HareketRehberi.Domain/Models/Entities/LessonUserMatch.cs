using System.ComponentModel.DataAnnotations.Schema;

namespace HareketRehberi.Domain.Models.Entities
{
    public class LessonUserMatch :BaseEntity
    {
        public int LessonId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public SystemUser User { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
    }
}
