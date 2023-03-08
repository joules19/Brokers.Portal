using Brokers.Portal.Modules.Underwriting.Models.VMs;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Brokers.Portal.Modules.Underwriting.Models
{
    public class RequestDto
    {
        [Key]
        public int Id { get; set; }
        public string? RequestId { get; set; }
        
        public string? BrokerId { get; set; }
        
        public int ProductId { get; set; }
        
        public int PackageId { get; set; }
        
        public string? InsuredName { get; set; }

        
        public string? Occupation { get; set; }

        
        public string? EmailAddress { get; set; }

        public string? TypeOfCover { get; set; }

        
        public string? VehicleMake { get; set; }
        
        public string? YearOfMake { get; set; }

        
        public DateTime InsuranceStartDate { get; set; }

        
        public decimal VehicleValue { get; set; }

        
        public DateTime StartDate { get; set; }

        

        public Decimal InsuredValue { get; set; }

        
        public string? ModeOfPayment { get; set; }

        
        public string? PolicyHolder { get; set; }

        
        public string? Mobile { get; set; }

        
        public string? Address { get; set; }

        
        public string? TypeOfUsage { get; set; }

        
        public string? RegistrationNumber { get; set; }

        
        public int PremiumRate { get; set; }

        
        public int CoverPeriod { get; set; }

        

        public DateTime TransactionDate { get; set; }

        
        public decimal Premium { get; set; }

        
        public string? IdUploadUrl { get; set; }

        
        public string? UtilityBillUploadUrl { get; set; }

        
        public string? VehicleLicenseUploadUrl { get; set; }

        public decimal BuildingValue { get; set; }


        public string? BuildingLocation { get; set; }


        public string? BuildingPurpose { get; set; }


        public DateTime DateCreated { get; set; }


        public static RequestDto FromMotor(Motor motor)
        {
            return new RequestDto
            {
                RequestId = motor.RequestId,
                BrokerId = motor.BrokerId,
                ProductId = motor.ProductId,
                PackageId = motor.PackageId,
                InsuredName = motor.InsuredName,
                Occupation = motor.Occupation,
                EmailAddress = motor.EmailAddress,
                TypeOfCover = motor.TypeOfCover,
                VehicleMake = motor.VehicleMake,
                YearOfMake = motor.YearOfMake,
                InsuranceStartDate = motor.InsuranceStartDate,
                VehicleValue = motor.VehicleValue,
                StartDate = motor.StartDate,
                InsuredValue = motor.InsuredValue,
                ModeOfPayment = motor.ModeOfPayment,
                PolicyHolder = motor.PolicyHolder,
                Mobile = motor.Mobile,
                Address = motor.Address,
                TypeOfUsage = motor.TypeOfUsage,
                RegistrationNumber = motor.RegistrationNumber,
                PremiumRate = motor.PremiumRate,
                CoverPeriod = motor.CoverPeriod,
                TransactionDate = motor.TransactionDate,
                Premium = motor.Premium,
                IdUploadUrl = motor.IdUploadUrl,
                UtilityBillUploadUrl = motor.IdUploadUrl,
                VehicleLicenseUploadUrl = motor.VehicleLicenseUploadUrl,
                DateCreated = motor.DateCreated,
            };
        }

    }
}
