using Brokers.Portal.Modules.Management.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Management.Domain.Infrastructure
{
    public class ManagementServices : IManagementServices
    {

        private readonly UserManagement _userManagement;
        private readonly RolesManagement _roleManagement;

        public ManagementServices(string connectionString)
        {
            _userManagement = new UserManagement(connectionString);
            _roleManagement = new RolesManagement(connectionString);

        }

        public ApplicationUser? GetUser(string email) => _userManagement.GetUser(email);

        public IEnumerable<ApplicationUser> GetUsers() => _userManagement.GetUsers();

        public string UpdateUser(User user) => _userManagement.UpdateUser(user);

        public string DeleteUser(string userId) => _userManagement.DeleteUser(userId);


        public string? CreateRole(string roleName) => _roleManagement.CreateRole(roleName);

        public Role? GetRole(int roleId) => _roleManagement.GetRole(roleId);

        public IEnumerable<Role> GetRoles() => _roleManagement.GetRoles();


        public ModuleDTO? GetModule(int moduleId) => _roleManagement.GetModule(moduleId);

        public ProcessDTO? GetProcess(int processId) => _roleManagement.GetProcess(processId);

        public IList<Roles> GetProcessFormPermission(List<int> roles) => _roleManagement.GetProcessFormPermission(roles);

        public bool ValidateRoleName(string roleName) => _roleManagement.ValidateRoleName(roleName);

        public IEnumerable<UserRoles> GetUserRoles(string userId) => _roleManagement.GetUserRoles(userId);

        public string? MapUserIdToRoles(string userId, int roleId) => _roleManagement.MapUserIdToRoles(userId, roleId);



    }
}
