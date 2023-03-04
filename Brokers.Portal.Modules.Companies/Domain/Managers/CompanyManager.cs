using Brokers.Portal.Modules.Users.Models;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Brokers.Portal.Modules.Company.Domain.Managers
{
    public class CompanyManager
    {
        public static string CreateCompany(IDbConnection db, CompanyDto model)
        {
            string sp = "spCompany_CreateCompany";

            DynamicParameters prm = new DynamicParameters();

            prm.Add("@CompanyId", model.CompanyId);
            prm.Add("@CompanyName", model.CompanyName);
            prm.Add("@Mobile", model.Mobile);
            prm.Add("@Email", model.Email);
            prm.Add("@City", model.City);
            prm.Add("@StreetAddress", model.CompanyAddress);
            prm.Add("@State", model.State);
            prm.Add("@PostalCode", model.PostalCode);
            prm.Add("@IsActive", model.IsActive);


            DbStore.SaveData(db, sp, prm);

            return "Quote submitted Successfully.";
        }

        public static IEnumerable<CompanyDto> GetCompanies(IDbConnection db)
        {

            DynamicParameters prm = new DynamicParameters();

            var result = DbStore.LoadData<CompanyDto>(db, "spCompany_GetAll", prm);

            return result;
        }

        public static CompanyDto? GetCompany(IDbConnection db, string companyId)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@CompanyId", companyId);

            var result = DbStore.LoadData<CompanyDto>(db, "spCompany_GetCompany", prm);

            return result.FirstOrDefault();
        }
    }
}
