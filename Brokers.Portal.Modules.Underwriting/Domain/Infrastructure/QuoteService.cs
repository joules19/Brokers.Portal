using Brokers.Portal.Modules.Underwriting.Domain.Manager;
using Brokers.Portal.Modules.Underwriting.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Underwriting.Domain.Infrastructure
{
    public class QuoteService
    {
        private readonly string _connectionString;
        public QuoteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServiceResult<string> SubmitRequestForMotor(MotorVM model)
        {
            ServiceResult<string> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var message = QuoteManager.SumbitRequestForMotor(db, model);
                result.Payload = message;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
