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

        public static ProductDto? GetProductById(IDbConnection db, int productId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@ProductId", productId);

            var results = DbStore.LoadData<ProductDto>(db, "spProduct_GetProductById", prm);

            return results.FirstOrDefault();
        }

        public static ProductDto? GetProductByName(IDbConnection db, string productName)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@ProductName", productName);

            var results = DbStore.LoadData<ProductDto>(db, "spProduct_GetProductByName", prm);

            return results.FirstOrDefault();
        }


        public static IEnumerable<PackageDto> GetPackagesByProductId(IDbConnection db, int productId)
        {
            DynamicParameters prm = new DynamicParameters();
            prm.Add("@ProductId", productId);

            var results = DbStore.LoadData<PackageDto>(db, "spPackage_GetPackagesByProductId", prm);


            return results;
        }

        public static PackageDto? GetPackageById(IDbConnection db, int packageId)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@PackageId", packageId);

            var results = DbStore.LoadData<PackageDto>(db, "spPackage_GetPackageById", prm);

            return results.FirstOrDefault();
        }

        public static PackageDto? GetPackageByName(IDbConnection db, string packageName)
        {
            DynamicParameters prm = new DynamicParameters();

            prm.Add("@PackageName", packageName);

            var results = DbStore.LoadData<PackageDto>(db, "spPackage_GetPackageByName", prm);

            return results.FirstOrDefault();
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
