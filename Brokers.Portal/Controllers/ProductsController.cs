using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Products.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static Brokers.Portal.Api.Models.Responses;

namespace Brokers.Portal.Controllers
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        /// <remarks>
        /// Sample Response:
        /// 
        ///     {
        ///           "error": {},
        ///           "data": [
        ///                {
        ///                  "id": 1,
        ///                 "productName": "Motor Policy"
        ///                },
        ///                {
        ///                  "id": 2,
        ///                 "productName": "HouseHolder Policy"
        ///                }
        ///            ]
        ///     }
        /// </remarks>
        /// <summary>
        ///     Returns all products.
        /// </summary>
        /// <response code="200">Returns Ok with the Products object.</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="404">If record is not found or an error occured while fetching products.</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getallproducts")]
        public IActionResult GetAllProducts()
        {
            var result = _productServices.GetAllProducts();
            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened while trying to get all products.", "");
                return new JsonResult(res)
                {
                    StatusCode = 404,
                };
            }

            var resX = Utilities.FormCustomResponse("", result.Payload);
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }



        /// <remarks>
        /// Sample Response:
        /// 
        ///     {
        ///           "error": {},
        ///           "data": [
        ///                {
        ///                     "id": 1,
        ///                     "packageName": "Comprehensive",
        ///                 },
        ///            ]
        ///     }
        /// </remarks>
        /// <summary>
        ///     Returns all packages by their respective product Id.
        /// </summary>
        /// <response code="200">Returns Ok with the Packages object.</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="404">If record is not found or an error occured while fetching packages.</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getpackages")]
        public IActionResult GetPackagesByProductId([FromQuery] int productId)
        {

            var result = _productServices.GetPackagesByProductId(productId);
            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse(result.ErrorMessage, "");
                return new JsonResult(res)
                {
                    StatusCode = 404,
                };
            }

            var resX = Utilities.FormCustomResponse("", result.Payload);
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }



        /// <remarks>
        /// Sample Response:
        /// 
        ///     {
        ///           "error": {},
        ///           "data": [
        ///                {
        ///                     "id": 1,
        ///                     "ExtensionName": "Excess Buy",
        ///                 },
        ///            ]
        ///     }
        /// </remarks>
        /// <summary>
        ///     Returns all extensions by their respective product Id.
        /// </summary>
        /// <response code="200">Returns Ok with the Extensions object.</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="404">If record is not found or an error occured while fetching extensions.</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getextensions")]
        public IActionResult GetExtensionsByProductId([FromQuery] int productId)
        {

            var result = _productServices.GetExtensionsByProductId(productId);
            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse(result.ErrorMessage, "");
                return new JsonResult(res)
                {
                    StatusCode = 404,
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
