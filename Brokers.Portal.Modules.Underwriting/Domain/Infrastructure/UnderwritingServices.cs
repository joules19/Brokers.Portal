using Brokers.Portal.Modules.Underwriting.Domain.Manager.Helpers;
using Brokers.Portal.Modules.Underwriting.Domain.Services;
using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;

namespace Brokers.Portal.Modules.Underwriting.Domain.Infrastructure
{
    public class UnderwritingServices : IUnderwritingServices
    {
        private readonly QuoteService _quoteService;
        public UnderwritingServices(string connectionstring)
        {
            _quoteService = new QuoteService(connectionstring);
        }

        public ServiceResult<string?> SubmitRequestForMotor(RequestDto model) => _quoteService.SubmitRequestForMotor(model);
        public ServiceResult<Motor?> GetRequestByRequestId(string requestId) => _quoteService.GetRequestByRequestId(requestId);

        public string? GenerateRequestId() => Utilities.GenerateRequestId();
    }
}
