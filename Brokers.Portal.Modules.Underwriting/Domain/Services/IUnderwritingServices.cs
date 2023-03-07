using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Underwriting.Domain.Services
{
    public interface IUnderwritingServices
    {
        ServiceResult<string> SubmitRequestForMotor(MotorVM model);
    }
}
