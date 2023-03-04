using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Underwriting.Models.VMs
{
    public class VehicleVM
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Mobile { get; set; }
        [Required]
        public string? Dob { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Occupation { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? IdentificationType { get; set; }
        [Required]
        public string? IdentificationNumber { get; set; }
        [Required]
        public IFormFile? IdUpload { get; set; }
        [Required]
        public string? IdUploadUrl { get; set; }
        [Required]
        public string? TypeOfCover { get; set; }
        [Required]
        public string? VehicleCategory { get; set; }
        [Required]
        public double VehicleValue { get; set; }
        [Required]
        public string? PaymentOption { get; set; }
        [Required]
        public string? VehicleMake { get; set; }
        [Required]
        public string? ModelOfVehicle { get; set; }
        [Required]
        public string? RegistrationNumber { get; set; }
        [Required]
        public string? ChasisNumber { get; set; }
        [Required]
        public string? EngineNumber { get; set; }
        [Required]
        public string? YearOfMake { get; set; }
        [Required]
        public string? CarBodyType { get; set; }
        [Required]
        public DateTime InsuranceStartDate { get; set; }
        [Required]
        public string? VehicleColor { get; set; }
        [Required]
        public double TotalCost { get; set; }
        public string DateCreated { get; set; }
    }
}
