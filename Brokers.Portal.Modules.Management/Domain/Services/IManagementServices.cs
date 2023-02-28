using Brokers.Portal.Modules.Users.Models;

namespace Brokers.Portal.Modules.Management.Domain.Services
{
    public interface IManagementServices
    {
        ApplicationUser? GetUser(string email);
        IEnumerable<ApplicationUser> GetUsers();
        string UpdateUser(User user);
        string DeleteUser(string userId);
        ModuleDTO? GetModule(int moduleId);
        ProcessDTO? GetProcess(int processId);
        //IEnumerable<ProcessFormMapping> GetProcessFormMapping(int roleId);
        IList<Roles> GetProcessFormPermission(List<int> roles);

        IEnumerable<UserRoles> GetUserRoles(string userId);
    }
}
