using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Underwriting.Models
{
    public class ServiceResult<T>
    {
        public  bool HasError { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Payload { get; set; }
    }
}
