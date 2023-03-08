using System.ComponentModel.DataAnnotations;

namespace Brokers.Portal.Modules.Underwriting.Models.VMs
{
    public class Motor
    {
        public string? RequestId { get; set; }
        [Required]
        public string? BrokerId { get; set; }
        [Required]

        public string? ProductName { get; set; }
        [Required]
        public string? TypeOfCover { get; set; }

        [Required]
        public string? InsuredName { get; set; }

        [Required]
        public string? Occupation { get; set; }

        [Required]
        public string? EmailAddress { get; set; }

        [Required]
        public string? VehicleMake { get; set; }
        [Required]
        public string? YearOfMake { get; set; }

        [Required]
        public DateTime InsuranceStartDate { get; set; }

        [Required]
        public decimal VehicleValue { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]

        public Decimal InsuredValue { get; set; }

        [Required]
        public string? ModeOfPayment { get; set; }

        [Required]
        public string? PolicyHolder { get; set; }

        [Required]
        public string? Mobile { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? TypeOfUsage { get; set; }

        [Required]
        public string? RegistrationNumber { get; set; }

        [Required]
        public int PremiumRate { get; set; }

        [Required]
        public int CoverPeriod { get; set; }

        [Required]

        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Premium { get; set; }

        [Required]
        public string? IdUploadUrl { get; set; }

        [Required]
        public string? UtilityBillUploadUrl { get; set; }

        [Required]
        public string? VehicleLicenseUploadUrl { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public int PackageId { get; set; }
    }
}
