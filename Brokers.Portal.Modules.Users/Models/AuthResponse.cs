using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Users.Models
{
    public class AuthResponse
    {

        public string? Message { get; set; }
        public UserData? Data { get; set; }
        public string? Token { get; set; }

    }
}
