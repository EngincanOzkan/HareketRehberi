namespace HareketRehberi.Domain.Models.Entities
{
    public class SystemUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public bool IsAdmin { get; set; }
    }
}
