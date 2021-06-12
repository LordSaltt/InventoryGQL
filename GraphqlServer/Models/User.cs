namespace GraphqlServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSaltt { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}