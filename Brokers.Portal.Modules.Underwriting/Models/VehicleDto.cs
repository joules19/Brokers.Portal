using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Brokers.Portal.Modules.Underwriting.Models
{
    public class VehicleDto
    {
        [Required]
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Dob { get; set; }
        public string? Gender { get; set; }
        public string? Occupation { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? IdentificationType { get; set; }
        public string? IdentificationNumber{ get; set; }
        public IFormFile? IdUpload { get; set; }
        public string? TypeOfCover { get; set; }
        public string? VehicleCategory { get; set; }
        public string? VehicleValue { get; set; }
        public string? PaymentOption { get; set; }
        public string? VehicleMake { get; set; }
        public string? ModelOfVehicle { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? ChasisNumber { get; set; }
        public string? EngineNumber { get; set; }
        public string? YearOfMake { get; set; }
        public string? CarBodyType { get; set; }
        public DateTime InsuranceStartDate { get; set; }
        public string? VehicleColor { get; set; }
        public double TotalCost { get; set; }

    }
}
