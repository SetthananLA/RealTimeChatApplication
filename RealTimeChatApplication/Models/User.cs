namespace RealTimeChatApplication.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserRole { get; set; }
        public string PasswordHash { get; set; }
    }
}
