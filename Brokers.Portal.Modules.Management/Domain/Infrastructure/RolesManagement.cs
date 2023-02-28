using Brokers.Portal.Modules.Management.Domain.Managers;
using Brokers.Portal.Modules.Management.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Models;

namespace Brokers.Portal.Modules.Management.Domain.Infrastructure
{
    public class RolesManagement
    {
        private readonly string _connectionString;
        public RolesManagement(string connectionString)
        {
            _connectionString = connectionString;
        }



        #region Roles

        public string? CreateRole(string roleName)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.CreateRole(db, roleName);
        }
        public Role? GetRole(int roleId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.GetRole(db, roleId);
        }
        public IEnumerable<Role> GetRoles()
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.GetRoles(db);
        }

        public bool ValidateRoleName(string roleName)
        {
            var results = GetRoles();

            var res = results.Where(x => x.RoleName == roleName);
            if (res.Count() > 0) return true;

            return false;
        }

        #endregion


        public ModuleDTO? GetModule(int moduleId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.GetModule(db, moduleId);
        }

        public ProcessDTO? GetProcess(int processId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.GetProcess(db, processId);
        }

        public IEnumerable<ProcessFormMapping> GetProcessFormMapping(int roleId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.GetProcessFormMapping(db, roleId);
        }

        public IList<Roles> GetProcessFormPermission(List<int> roles)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);
            ApplicationRoles applicationRoles = new ApplicationRoles();

            foreach (var roleId in roles)
            {
                IEnumerable<ProcessFormMapping> processFormMapping = GetProcessFormMapping(roleId);

                var roleName = GetRole(roleId).RoleName;

                if (roleName != null)
                {
                    Roles rolesX = new Roles();
                    foreach (var item in processFormMapping)
                    {

                        var moduleName = GetModule(item.ModuleId)?.ModuleName;
                        if (!rolesX.Modules.Contains(moduleName))
                        {
                            rolesX.Modules.Add(moduleName);
                        }

                        var processName = GetProcess(item.ProcessId)?.ProcessName;
                        if (!rolesX.Processes.Contains(processName))
                        {
                            rolesX.Processes.Add(processName);
                        }

                        Form form = new Form()
                        {
                            ModuleName = moduleName,
                            ProcessName = processName,
                            FormName = item.FormName,
                            CanCreate = item.CanCreate,
                            CanView = item.CanView,
                            CanEdit = item.CanEdit,
                            CanDelete = item.CanDelete,
                        };

                        
                        rolesX.Forms.Add(form);
                    }

                    rolesX.Rolename = roleName;
                    applicationRoles.AllRoles?.Add(rolesX);
                }
            }

            return applicationRoles.AllRoles;

        }

        public IEnumerable<UserRoles> GetUserRoles(string userId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.GetUserRoles(db, userId);
        }

        public string? MapUserIdToRoles(string userId, int roleId)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionString);

            return RoleManager.MapUserIdToRoles(db, userId, roleId);
        }
    }
}
