using Brokers.Portal.Modules.Products.Domain.Services;
using Brokers.Portal.Modules.Products.Models;
using Brokers.Portal.Modules.Users.Domain.Managers;
using Brokers.Portal.Modules.Users.Domain.Managers.Helpers;

namespace Brokers.Portal.Modules.Products.Domain.Infrastructure
{
    public class ProductServices : IProductServices
    {
        private readonly string _connectionString;
        public ProductServices(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public ServiceResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            ServiceResult<IEnumerable<ProductDto>> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var products = ProductManager.GetAllProducts(db);
                result.Payload = products;
            }
            catch (Exception ex)
            {

                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ServiceResult<IEnumerable<PackageDto>> GetPackagesByProductId(int productId)
        {
            ServiceResult<IEnumerable<PackageDto>> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var packages = ProductManager.GetPackagesByProductId(db, productId);
                result.Payload = packages;
            }
            catch (Exception ex)
            {

                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public ServiceResult<IEnumerable<ExtensionDto>> GetExtensionsByProductId(int productId)
        {
            ServiceResult<IEnumerable<ExtensionDto>> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var extensions = ProductManager.GetExtensionsByProductId(db, productId);
                result.Payload = extensions;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;

 
        }

    }
}
