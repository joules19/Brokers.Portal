using Brokers.Portal.Modules.Products.Models;

namespace Brokers.Portal.Modules.Products.Domain.Services
{
    public interface IProductServices
    {
        ServiceResult<IEnumerable<ProductDto>> GetAllProducts();
        ServiceResult<ProductDto> GetProductByName(string productName);
        ServiceResult<ProductDto> GetProductById(int productId);

        ServiceResult<IEnumerable<PackageDto>> GetPackagesByProductId(int productId);
        ServiceResult<PackageDto> GetPackageByName(string packageName);
        ServiceResult<PackageDto> GetPackageById(int packageId);

        ServiceResult<IEnumerable<ExtensionDto>> GetExtensionsByProductId(int productId);
    }
}
