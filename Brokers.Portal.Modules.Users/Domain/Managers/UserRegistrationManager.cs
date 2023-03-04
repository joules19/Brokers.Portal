using Brokers.Portal.Modules.Users.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Models;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Brokers.Portal.Modules.Users.Domain.Managers
{
    public class UserRegistrationManager
    {
        public static string RegisterUser(IDbConnection db, UserDTO user)
        {
            string sp = "spUser_AddUser";

            DynamicParameters prm = new DynamicParameters();

            var pHash = Utilities.HashPassword(user.Password);
            var guid = Guid.NewGuid();

            prm.Add("@UserId", guid.ToString());
            prm.Add("@Email", user.Email);
            prm.Add("@Username", user.Email);
            prm.Add("@PasswordHash", pHash);
            prm.Add("@PasswordSalt", pHash);
            prm.Add("@DateCreated", DateTime.Now);
            prm.Add("@CompanyId", user.CompanyId);


            DbStore.SaveData(db, sp, prm);

            return "User Registered Successfully.";
        }

    }
}
