using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using Dapper;
using Microsoft.AspNetCore.Http;
using Rds.Utilities.Database.ReadWrite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Underwriting.Domain.Manager
{
    public class QuoteManager
    {
        public static string? SumbitRequestForMotor(IDbConnection db, RequestDto model)
        {
            string sp = "spQuote_SubmitRequestForMotor";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@RequestId", model.RequestId);
            prm.Add("@BrokerId", model.BrokerId);
            prm.Add("@ProductId", model.ProductId);
            prm.Add("@PackageId", model.PackageId);
            prm.Add("@InsuredName", model.InsuredName);
            prm.Add("@Occupation", model.Occupation);
            prm.Add("@EmailAddress", model.EmailAddress);
            prm.Add("@TypeOfCover", model.TypeOfCover);
            prm.Add("@VehicleMake", model.VehicleMake);
            prm.Add("@YearOfMake", model.YearOfMake);
            prm.Add("@InsuranceStartDate", model.InsuranceStartDate);
            prm.Add("@VehicleValue", model.VehicleValue);
            prm.Add("@InsuredValue", model.InsuredValue);
            prm.Add("@ModeOfPayment", model.ModeOfPayment);
            prm.Add("@PolicyHolder", model.PolicyHolder);
            prm.Add("@Mobile", model.Mobile);
            prm.Add("@Address", model.Address);
            prm.Add("@TypeOfUsage", model.TypeOfUsage);
            prm.Add("@RegistrationNumber", model.RegistrationNumber);
            prm.Add("@CoverPeriod", model.CoverPeriod);
            prm.Add("@PremiumRate", model.PremiumRate);
            prm.Add("@Premium", model.Premium);
            prm.Add("@IdUploadUrl", model.IdUploadUrl);
            prm.Add("@UtilityBillUploadUrl", model.UtilityBillUploadUrl);
            prm.Add("@VehicleLicenseUploadUrl", model.VehicleLicenseUploadUrl);
            prm.Add("@BuildingValue", model.BuildingValue);
            prm.Add("@BuildingLocation", model.BuildingLocation);
            prm.Add("@BuildingPurpose", model.BuildingPurpose);
            prm.Add("@DateCreated", model.DateCreated);

            DbStore.SaveData(db, sp, prm);

            return model.RequestId;
        }

        public static RequestDto? GetRequestByRequestId(IDbConnection db, string requestId)
        {
            string sp = "spQuote_GetRequestByRequestId";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@RequestId", requestId);

            var requestData = DbStore.LoadData<RequestDto>(db, sp, prm);

            return requestData.FirstOrDefault();
        }
    }
}