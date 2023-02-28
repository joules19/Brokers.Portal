using System.ComponentModel.DataAnnotations.Schema;

namespace Brokers.Portal.Modules.Users.Models
{
    public class UserFormPermission
    {
        public int UserFormPermissionId { get; set; }
        public string UserId { get; set; }
        public string FormName { get; set; }
        public string FormRoute { get; set; }
        public string PermissionName { get; set; }
        public string ActionName { get; set; }
        public string ProcesssName { get; set; }
        public string ModuleName { get; set; }
        public int RoleId { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }

    }
}
