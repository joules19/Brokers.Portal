using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Management.Models
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string? ApplicationName { get; set; }
        public string? PasswordHash { get; set; }

    }
}
