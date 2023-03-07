using Brokers.Portal.Modules.Management.Models;
using Brokers.Portal.Modules.Users.Models;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Brokers.Portal.Modules.Management.Domain.Managers
{
    public class AppManager
    {

        public static ApplicationDTO? GetApplicationInfo(IDbConnection db, string applicationName)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@ApplicationName", applicationName);

            return DbStore.LoadData<ApplicationDTO>(db, "spApplication_AddApplication", prm).FirstOrDefault();
        }
    }
}