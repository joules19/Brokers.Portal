using Brokers.Portal.Modules.Underwriting.Domain.Manager;
using Brokers.Portal.Modules.Underwriting.Domain.Manager.Helpers;
using Brokers.Portal.Modules.Underwriting.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using Serilog;

namespace Brokers.Portal.Modules.Underwriting.Domain.Infrastructure
{
    public class QuoteService
    {
        private readonly string _connectionString;
        public QuoteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServiceResult<string?> SubmitRequestForMotor(RequestDto model)
        {
            ServiceResult<string?> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                model.RequestId = Utilities.GenerateRequestId();
                model.DateCreated = DateTime.Now;
                model.InsuranceStartDate = DateTime.Now;

                //var modelX = RequestDto.Fromres(model);

                var res = QuoteManager.SumbitRequestForMotor(db, model);

                result.Payload = res;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;

                Log.Information(ex.Message);
            }

            return result;
        }

        public ServiceResult<Motor?> GetRequestByRequestId(string requestId)
        {
            ServiceResult<Motor?> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var res = QuoteManager.GetRequestByRequestId(db, requestId);

                if (res == null)
                {
                    result.HasError = true;
                    result.ErrorMessage = "No record found with that request Id.";
                }

                var requestData = new Motor()
                {
                    RequestId = res.RequestId,
                    BrokerId = res.BrokerId,
                    ProductId = res.ProductId,
                    PackageId = res.PackageId,
                    InsuredName = res.InsuredName,
                    Occupation = res.Occupation,
                    EmailAddress = res.EmailAddress,
                    TypeOfCover = res.TypeOfCover,
                    VehicleMake = res.VehicleMake,
                    YearOfMake = res.YearOfMake,
                    InsuranceStartDate = res.InsuranceStartDate,
                    VehicleValue = res.VehicleValue,
                    StartDate = res.StartDate,
                    InsuredValue = res.InsuredValue,
                    ModeOfPayment = res.ModeOfPayment,
                    PolicyHolder = res.PolicyHolder,
                    Mobile = res.Mobile,
                    Address = res.Address,
                    TypeOfUsage = res.TypeOfUsage,
                    RegistrationNumber = res.RegistrationNumber,
                    PremiumRate = res.PremiumRate,
                    CoverPeriod = res.CoverPeriod,
                    TransactionDate = res.TransactionDate,
                    Premium = res.Premium,
                    IdUploadUrl = res.IdUploadUrl,
                    UtilityBillUploadUrl = res.IdUploadUrl,
                    VehicleLicenseUploadUrl = res.VehicleLicenseUploadUrl,
                    DateCreated = res.DateCreated,
                };

                result.Payload = requestData;
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
