using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Products.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;
using static Brokers.Portal.Api.Models.Responses;

namespace Brokers.Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getall")]
        public IActionResult GetAllProducts()
        {
            var result = _productServices.GetAllProducts();
            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened please try again", "");
                return new JsonResult(res)
                {
                    StatusCode = 500,
                };
            }

            var resX = Utilities.FormCustomResponse("", result.Payload);
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }

        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getpackages")]
        public IActionResult GetPackagesByProductId(int productId)
        {

            var result = _productServices.GetPackagesByProductId(productId);
            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened please try again", "");
                return new JsonResult(res)
                {
                    StatusCode = 500,
                };
            }

            var resX = Utilities.FormCustomResponse("", result.Payload);
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }


        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getextensions")]
        public IActionResult GetExtensionsByProductId(int productId)
        {

            var result = _productServices.GetExtensionsByProductId(productId);
            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened please try again", "");
                return new JsonResult(res)
                {
                    StatusCode = 500,
                };
            }

            var resX = Utilities.FormCustomResponse("", result.Payload);
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }
    }
}
