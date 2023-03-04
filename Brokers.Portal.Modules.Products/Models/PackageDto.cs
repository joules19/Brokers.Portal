using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Products.Models
{
    public class PackageDto
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public int ProductId { get; set; }

    }
}
