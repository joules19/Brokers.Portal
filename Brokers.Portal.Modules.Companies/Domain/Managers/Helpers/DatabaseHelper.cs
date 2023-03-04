using System.Data;
using System.Data.SqlClient;

namespace Brokers.Portal.Modules.Company.Domain.Managers.Helpers
{
	public static class DatabaseHelper
    {
        public static IDbConnection OpenDatabase(string connectionString)
        {
			try
			{
				var db = new SqlConnection(connectionString);
				db.Open();

				return db;
			}
			catch (Exception ex)
			{

				throw new InvalidOperationException("Cannot open the SQL server database.", ex);
			}
        }
    }
}
