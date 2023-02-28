using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Users.Models
{
    public class CustomResponseDTO
    {

        public string StatusCode { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public List<object>? result { get; set; }

        public CustomResponseDTO()
        {
            result = new List<object>();
        }
    }
}
