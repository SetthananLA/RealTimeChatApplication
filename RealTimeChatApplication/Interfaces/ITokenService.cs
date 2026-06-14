using RealTimeChatApplication.Models;

namespace RealTimeChatApplication.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(UserModel user);
    }
}
