using Brokers.Portal.Modules.Users.Models;
using Microsoft.IdentityModel.Tokens;

namespace Brokers.Portal.Modules.Users.Domain.Services
{
    public interface IUserServices
    {
        ServiceResult<string> RegisterUser(UserDTO user);
        AuthResponse ProcessUserLoginRequest(UserDTO request);
        string? CreateToken(ApplicationUser user, SecurityKey secretKey);
        bool CheckPasswordHash(string password, string storedPW);
    }
}
