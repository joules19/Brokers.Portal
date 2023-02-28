namespace Brokers.Portal.Modules.Users.Models
{
    public class ProcessFormMapping
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public string FormName { get; set; } = string.Empty;
        public int ProcessId { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }
    }
}
