using Brokers.Portal.Modules.Users.Domain.Managers;
using Brokers.Portal.Modules.Users.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.IdentityModel.Tokens;
using Serilog;
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

        public ServiceResult<string> RegisterUser(UserDTO user)
        {
            ServiceResult<string> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                string message = UserRegistrationManager.RegisterUser(db, user);

                if (message.IsNullOrEmpty()) throw new Exception(message);

                result.Payload = message;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;

                Log.Information(ex.Message);
            }

            return result;
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
