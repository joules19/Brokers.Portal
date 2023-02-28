using Brokers.Portal.Modules.Management.Domain.Managers;
using Brokers.Portal.Modules.Management.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Models;

namespace Brokers.Portal.Modules.Management.Domain.Infrastructure
{
    public class UserManagement
    {
        private readonly string _connectionString;
        public UserManagement(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationUser? GetUser(string email)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return UserManager.GetUser(db, email);
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
    }
}
