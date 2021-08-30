namespace HareketRehberi.Domain.Models.Requests
{
    public class SystemUserRequest
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
    }
}
