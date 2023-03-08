using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;

namespace Brokers.Portal.Modules.Underwriting.Domain.Services
{
    public interface IUnderwritingServices
    {
        ServiceResult<string?> SubmitRequestForMotor(RequestDto model);
        ServiceResult<Motor?> GetRequestByRequestId(string requestId);
    }
}
