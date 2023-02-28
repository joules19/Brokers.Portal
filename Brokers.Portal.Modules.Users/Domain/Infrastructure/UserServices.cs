using Brokers.Portal.Modules.Users.Domain.Managers;
using Brokers.Portal.Modules.Users.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Brokers.Portal.Modules.Users.Domain.Infrastructure
{
    public class UserServices : IUserServices
    {
        private readonly string _connectionString;
        public UserServices(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public string RegisterUser(UserDTO user)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return UserRegistrationManager.RegisterUser(db, user);
        }


        public AuthResponse ProcessUserLoginRequest(UserDTO user)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return new AuthResponse();
        }

        public string? CreateToken(ApplicationUser user, SecurityKey secretKey)
        {
            return Utilities.CreateToken(user, secretKey);
        }

        public bool CheckPasswordHash(string password, string storedPW)
        {
            return Utilities.CheckPasswordHash(password, storedPW);
        }

    }
}
