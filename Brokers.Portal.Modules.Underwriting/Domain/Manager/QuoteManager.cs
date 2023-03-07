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
        public static string SumbitRequestForMotor(IDbConnection db, MotorVM model)
        {
            string sp = "spQuote_SubmitQuoteForVehicle";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@Title", model.Title);
            prm.Add("@FirstName", model.FirstName);
            prm.Add("@Surname", model.Surname);
            prm.Add("@Email", model.Email);
            prm.Add("@Mobile", model.Mobile);
            prm.Add("@Dob", model.Dob);
            prm.Add("@Gender", model.Gender);
            prm.Add("@Occupation", model.Occupation);
            prm.Add("@Address", model.Address);
            prm.Add("@State", model.State);
            prm.Add("@IdentificationType", model.IdentificationType);
            prm.Add("@IdentificationNumber", model.IdentificationNumber);
            prm.Add("@IdUpload", model.IdUpload);
            prm.Add("@IdUploadUrl", model.IdUploadUrl);
            prm.Add("@TypeOfCover", model.TypeOfCover);
            prm.Add("@VehicleCategory", model.VehicleCategory);
            prm.Add("@VehicleValue", model.VehicleValue);
            prm.Add("@PaymentOption", model.PaymentOption);
            prm.Add("@VehicleMake", model.VehicleMake);
            prm.Add("@ModelOfVehicle", model.ModelOfVehicle);
            prm.Add("@RegistrationNumber", model.RegistrationNumber);
            prm.Add("@ChasisNumber", model.ChasisNumber);
            prm.Add("@EngineNumber", model.EngineNumber);
            prm.Add("@YearOfMake", model.YearOfMake);
            prm.Add("@InsuranceStartDate", model.InsuranceStartDate);
            prm.Add("@VehicleColor", model.VehicleColor);
            prm.Add("@TotalCost", model.TotalCost);
            prm.Add("@DateCreated", model.DateCreated);


            DbStore.SaveData(db, sp, prm);

            return "Request submitted Successfully.";
        }
    }
}