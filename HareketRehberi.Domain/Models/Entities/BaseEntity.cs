using System.ComponentModel.DataAnnotations;

namespace HareketRehberi.Domain.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
