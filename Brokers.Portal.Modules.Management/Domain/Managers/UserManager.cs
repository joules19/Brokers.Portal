using Brokers.Portal.ExceptionHandling;
using Brokers.Portal.Modules.Users.Models;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Management.Domain.Managers
{
    public class UserManager
    {
        public static ApplicationUser? GetUser(IDbConnection db, string email)
        {

            string sp = "spUser_GetUser";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@Email", email);

            var result = DbStore.LoadData<ApplicationUser>(db, sp, prm);

            if (result.Count < 1) throw new DomainNotFoundException("User with that email address does not exist.");

            return result.FirstOrDefault();

        }

        public static IEnumerable<ApplicationUser> GetUsers(IDbConnection db)
        {

            var results = DbStore.LoadData<ApplicationUser>(db, "spUser_GetAll", null);

            return results;
        }

        public static string UpdateUser(IDbConnection db, User user)
        {
         
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@FirstName", user.FirstName);
            prm.Add("@MiddleName", user.MiddleName);
            prm.Add("@LastName", user.LastName);
            prm.Add("@Mobile", user.Mobile);
            prm.Add("@IsProfileUpdated", user.isProfileUpdated);

            DbStore.SaveData(db, "spUser_UpdateUser", prm);

            return "User information updated Successfully.";
        }

        public static string DeleteUser(IDbConnection db, string userId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@UserId", userId);

            DbStore.SaveData(db, "dbo.spUser_DeleteUser", prm);

            return "User deleted Successfully.";
        }

        public static ApplicationUser? GetUserById(IDbConnection db, string userId)
        {
            string sp = "spUser_GetUserById";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@UserId", userId);

            var result = DbStore.LoadData<ApplicationUser>(db, sp, prm);


            return result.FirstOrDefault();
        }
    }
}
