using Brokers.Portal.Modules.Products.Models;

namespace Brokers.Portal.Modules.Products.Domain.Services
{
    public interface IProductServices
    {
        ServiceResult<IEnumerable<ProductDto>> GetAllProducts();
        ServiceResult<IEnumerable<PackageDto>> GetPackagesByProductId(int productId);
        ServiceResult<IEnumerable<ExtensionDto>> GetExtensionsByProductId(int productId);
    }
}
