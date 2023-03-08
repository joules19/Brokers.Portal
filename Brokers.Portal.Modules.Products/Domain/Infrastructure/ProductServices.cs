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

        public ServiceResult<ProductDto> GetProductById(int productId)
        {
            ServiceResult<ProductDto> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var product = ProductManager.GetProductById(db, productId);

                if (product == null)
                {
                    result.HasError = true;
                    result.ErrorMessage = "No record found with that product Id";
                }
                result.Payload = product;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public ServiceResult<ProductDto> GetProductByName(string productName)
        {
            ServiceResult<ProductDto> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var product = ProductManager.GetProductByName(db, productName);

                if (product == null)
                {
                    result.HasError = true;
                    result.ErrorMessage = "The Product name is not valid";
                }
                result.Payload = product;
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

                if(packages.Count() < 1)
                {
                    result.HasError = true;
                    result.ErrorMessage = "No record(s) found with that product Id";
                }
                result.Payload = packages;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ServiceResult<PackageDto> GetPackageById(int packageId)
        {
            ServiceResult<PackageDto> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var package = ProductManager.GetPackageById(db, packageId);

                if (package == null)
                {
                    result.HasError = true;
                    result.ErrorMessage = "No record found with that package Id";
                }
                result.Payload = package;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        public ServiceResult<PackageDto> GetPackageByName(string packageName)
        {
            ServiceResult<PackageDto> result = new();
            try
            {
                using var db = DatabaseHelper.OpenDatabase(_connectionString);

                var package = ProductManager.GetPackageByName(db, packageName);

                if (package == null)
                {
                    result.HasError = true;
                    result.ErrorMessage = "The Package name is not valid";
                }
                result.Payload = package;
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

                if (extensions.Count() < 1)
                {
                    result.HasError = true;
                    result.ErrorMessage = "No record(s) found with that product Id";
                }
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
