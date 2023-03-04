using Brokers.Portal.Modules.Company.Models;
using Brokers.Portal.Modules.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Company.Domain.Services
{
    public interface ICompanyServices

    {
        ServiceResult<string?> CreateCompany(CompanyDto company);
        ServiceResult<string?> GenerateCompanyId();
        ServiceResult<IEnumerable<CompanyDto>> GetCompanies();
        ServiceResult<CompanyDto?> GetCompanyByCompanyId(string companyId);
    }
}
