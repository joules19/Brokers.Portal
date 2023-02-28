using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Users.Models
{
    public class ApplicationUser
    {
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public int RoleId { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public bool isActive { get; set; } = false;
        public bool isEmailVerified { get; set; } = false;
        public bool isProfileUpdated { get; set; } = false;
        public byte[] PHash { get; set; }
        public byte[] PSalt { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
}
