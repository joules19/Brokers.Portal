using Brokers.Portal.MiddleWares;
using Brokers.Portal.Modules.Management.Domain.Managers;
using Brokers.Portal.Modules.Management.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Management.Models;
using Serilog;

namespace Brokers.Portal.Modules.Management.Domain.Infrastructure
{
    public class ApplicationManagement
    {
        private readonly string _connectionString;
        public ApplicationManagement(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServiceResult<ApplicationDTO?> GetApplication(string applicationName)
        {
            ServiceResult<ApplicationDTO?> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                 var applicationInfo = AppManager.GetApplicationInfo(db, applicationName);

                if (applicationInfo == null) throw new DomainNotFoundException("Application Information does not exist.");

                result.Payload = applicationInfo;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;

                Log.Information(ex.Message);
            }

            return result;

        }
    }
}
