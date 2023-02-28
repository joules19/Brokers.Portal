using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokers.Portal.Modules.Management.Domain.Managers.Helpers
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
