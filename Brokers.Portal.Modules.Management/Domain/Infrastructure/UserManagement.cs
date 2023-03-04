using Brokers.Portal.ExceptionHandling;
using Brokers.Portal.Modules.Management.Domain.Managers;
using Brokers.Portal.Modules.Management.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Domain.Managers;
using Brokers.Portal.Modules.Users.Models;
using Serilog;

namespace Brokers.Portal.Modules.Management.Domain.Infrastructure
{
    public class UserManagement
    {
        private readonly string _connectionString;
        public UserManagement(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServiceResult<ApplicationUser?> GetUser(string email)
        {
            ServiceResult<ApplicationUser> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                 var user = UserManager.GetUser(db, email);

                if (user == null) throw new DomainNotFoundException("User with that email address does not exist.");

                result.Payload = user;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;

                Log.Information(ex.Message);
            }

            return result;

        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return UserManager.GetUsers(db);
        }

        
        
        public string UpdateUser(User user)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return UserManager.UpdateUser(db, user);
        }

        public string DeleteUser(string userId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return UserManager.DeleteUser(db, userId);
        }

        public ServiceResult<ApplicationUser?> GetUserById(string userId)
        {
            ServiceResult<ApplicationUser> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var user = UserManager.GetUserById(db, userId);
                if (user == null) throw new DomainNotFoundException("User with that Id does not exist.");
                result.Payload = user;

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
