using Brokers.Portal.Modules.Products.Models;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Brokers.Portal.Modules.Users.Domain.Managers
{
    public class ProductManager
    {
        public static IEnumerable<ProductDto> GetAllProducts(IDbConnection db)
        {
            DynamicParameters prm = new DynamicParameters();

            var results = DbStore.LoadData<ProductDto>(db, "spProduct_GetAll", prm);

            return results;
        }

        public static IEnumerable<PackageDto> GetPackagesByProductId(IDbConnection db, int productId)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@ProductId", productId);

            var results = DbStore.LoadData<PackageDto>(db, "spPackage_GetPackagesByProductId", prm);

            return results;
        }

        public static IEnumerable<ExtensionDto> GetExtensionsByProductId(IDbConnection db, int productId)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@ProductId", productId);

            var results = DbStore.LoadData<ExtensionDto>(db, "spExtension_GetExtensionsByProductId", prm);

            return results;
        }

    }
}
