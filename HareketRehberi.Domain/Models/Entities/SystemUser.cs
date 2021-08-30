using System.ComponentModel.DataAnnotations;

namespace HareketRehberi.Domain.Models.Entities
{
    public class SystemUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
    }
}
