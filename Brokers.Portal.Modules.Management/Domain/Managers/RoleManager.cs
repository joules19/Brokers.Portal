using Brokers.Portal.Modules.Management.Models;
using Brokers.Portal.Modules.Users.Models;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Brokers.Portal.Modules.Management.Domain.Managers
{
    public class RoleManager
    {

        #region Roles
        public static string CreateRole(IDbConnection db, string roleName)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@RoleName", roleName);
            DbStore.SaveData(db, "spRole_AddRole", prm);
            return "Role added successfully";
        }


        public static Role? GetRole(IDbConnection db, int roleId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@Id", roleId);

            var result = DbStore.LoadData<Role>(db, "spRole_GetRole", prm).FirstOrDefault();
            return result;
        }

        public static IEnumerable<Role> GetRoles(IDbConnection db)
        {
            DynamicParameters prm = new DynamicParameters();

            return DbStore.LoadData<Role>(db, "spRole_GetRoles", prm);
        }
        #endregion


        public static ModuleDTO? GetModule(IDbConnection db, int moduleId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@Id", moduleId);

            return DbStore.LoadData<ModuleDTO>(db, "spModule_GetModule", prm).FirstOrDefault();
        }

        public static ProcessDTO? GetProcess(IDbConnection db, int processId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@Id", processId);

            return DbStore.LoadData<ProcessDTO>(db, "spProcess_GetProcess", prm).FirstOrDefault();
        }

        public static IEnumerable<ProcessFormMapping> GetProcessFormMapping(IDbConnection db, int roleId)

        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@RoleId", roleId);

            return DbStore.LoadData<ProcessFormMapping>(db, "spProcessFormMapping_GetMapping", prm);
        }

        public static IEnumerable<UserRoles> GetUserRoles(IDbConnection db, string userId)
        {
            DynamicParameters prm = new DynamicParameters();

            userId.ToString();

            string id = userId.ToString();

            prm.Add("@UserId", id, DbType.String);

            var results = DbStore.LoadData<UserRoles>(db, "spUserRole_GetUserRole", prm);

            return results;
        }

        public static string? MapUserIdToRoles(IDbConnection db, string userId, int roleId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@UserId", userId);
            prm.Add("@RoleId", roleId);

            DbStore.SaveData(db, "spUserRole_AddUserRole", prm);
            return "UserRole added successfully";
        }
    }
}