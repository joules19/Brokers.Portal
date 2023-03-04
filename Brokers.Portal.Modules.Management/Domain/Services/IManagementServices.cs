using Brokers.Portal.Modules.Users.Models;

namespace Brokers.Portal.Modules.Management.Domain.Services
{
    public interface IManagementServices
    {
        ServiceResult<ApplicationUser?> GetUser(string email);
        ServiceResult<ApplicationUser?> GetUserById(string userId);
        IEnumerable<ApplicationUser> GetUsers();
        string UpdateUser(User user);
        string DeleteUser(string userId);
        ModuleDTO? GetModule(int moduleId);
        ProcessDTO? GetProcess(int processId);
        //IEnumerable<ProcessFormMapping> GetProcessFormMapping(int roleId);
        IList<Roles> GetProcessFormPermission(List<int> roles);

        IEnumerable<UserRoles> GetUserRoles(string userId);
        string MapUserIdToRoles(string userId, int roleId);
    }
}
