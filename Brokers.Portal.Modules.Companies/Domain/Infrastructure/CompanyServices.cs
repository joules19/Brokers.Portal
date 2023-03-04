using Brokers.Portal.Modules.Company.Domain.Managers;
using Brokers.Portal.Modules.Company.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Company.Domain.Services;
using Brokers.Portal.Modules.Company.Models;
using Brokers.Portal.Modules.Users.Domain.Managers.Helpers;
using Brokers.Portal.Modules.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Company.Domain.Infrastructure
{
    public class CompanyServices : ICompanyServices
    {
        private readonly string _connectionString;
        public CompanyServices(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ServiceResult<string?> CreateCompany(CompanyDto company)
        {
            ServiceResult<string?> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);
                var message = CompanyManager.CreateCompany(db, company);

                result.Payload = message;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ServiceResult<IEnumerable<CompanyDto>> GetCompanies() {
            ServiceResult<IEnumerable<CompanyDto>> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);
                var companies = CompanyManager.GetCompanies(db);

                result.Payload = companies;
            }
            catch (Exception ex)
            {

                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ServiceResult<CompanyDto?> GetCompanyByCompanyId(string companyId)
        {
            ServiceResult<CompanyDto?> result = new();

            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);
                var company = CompanyManager.GetCompany(db, companyId);

                result.Payload = company;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;

           
            }

            return result;
        }

        public ServiceResult<string?> GenerateCompanyId()
        {
            ServiceResult<string?> result = new();
            var companyId = Utilities.GenerateCompanyId();

            result.Payload = companyId;

            return result;
        }

    }
}
