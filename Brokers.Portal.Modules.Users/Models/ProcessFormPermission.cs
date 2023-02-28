using System.Collections.Generic;

namespace Brokers.Portal.Modules.Users.Models
{

    public class UserProfile
    {
        public UserData Profile { get; set; }

    }
    public class UserData
    {
        public UserDataDTO UserInfo { get; set; }
        public List<UserRolesX> Roles { get; set; }

        public UserData()
        {
            Roles = new List<UserRolesX>();
        }
    }
    public class UserRolesX
    {
        public string RoleName { get; set; }
        public List<Permissions> UserPermissions { get; set; }

        public UserRolesX()
        {
            UserPermissions = new List<Permissions>();
        }
    }

    public class Permissions
    {
        public List<Processes> Processes { get; set; }

        public Permissions()
        {
            Processes = new List<Processes>();
        }
    }

    public class Processes
    {
        public List<Process> ProcessesX { get; set; }

        public Processes()
        {
            ProcessesX = new List<Process>();
        }
    }

    public class Process
    {
        public string? ProcessName { get; set; }
        public List<Form> Forms { get; set; }

        public Process()
        {
            Forms = new List<Form>();
        }
    }

    public class Form
    {
        public string? FormName { get; set; }
        public string? ModuleName { get; set; }
        public string? ProcessName { get; set; }
        public bool CanCreate { get; set; } = false;
        public bool CanView { get; set; } = false;
        public bool CanEdit { get; set; } = false;
        public bool CanDelete { get; set; } = false;

    }

    public class Roles
    {
        public string Rolename { get; set; }
        public List<string?> Modules { get; set; }
        public List<string?> Processes { get; set; }
        public List<Form> Forms { get; set; }

        public Roles()
        {
            Modules = new List<string?>();
            Processes = new List<string?>();
            Forms = new List<Form>();
        }
    }

    public class ApplicationRoles
    {
        public IList<Roles>? AllRoles { get; set; }

        public ApplicationRoles()
        {
            AllRoles = new List<Roles>();
        }


    }


}
