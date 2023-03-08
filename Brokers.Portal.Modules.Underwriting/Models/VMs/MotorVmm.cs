using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Brokers.Portal.Modules.Underwriting.Models.VMs
{

    public class MotorVmm
    {
        [Required]
        public string? InsuredName { get; set; }

        [Required]
        public string? Occupation { get; set; }

        [Required]
        public string? EmailAddress { get; set; }

        [Required]
        public string? TypeCover { get; set; }

        [Required]
        public string? MakeVehicle { get; set; }
        [Required]
        public string? YearMake { get; set; }

        [Required]
        public decimal VehicleValue { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int InsuredValue { get; set; }

        [Required]
        public string? ModePayment { get; set; }

        [Required]
        public string? PolicyHolder { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? TypeUsage { get; set; }

        [Required]
        public int RegNumber { get; set; }

        [Required]
        public int PremiumRate { get; set; }

        [Required]
        public string? CoverPeriod { get; set; }

        public DateTime TransDate { get; set; }

        [Required]
        public decimal Premium { get; set; }

        [Required]
        public string? ValidID { get; set; }

        [Required]
        public string? UtilityBill { get; set; }

        [Required]
        public string? VehicleLicense { get; set; }
    }
}
