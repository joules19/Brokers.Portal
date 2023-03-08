using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Management.Domain.Services;
using Brokers.Portal.Modules.Products.Domain.Services;
using Brokers.Portal.Modules.Underwriting.Domain.Services;
using Brokers.Portal.Modules.Underwriting.Models;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Brokers.Portal.Controllers
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class UnderwritingController : ControllerBase
    {
        private readonly IUnderwritingServices _underwritingServices;
        private readonly IProductServices _productServices;
        private readonly IManagementServices _managementServices;

        public UnderwritingController(IUnderwritingServices underwritingServices, IProductServices productServices, IManagementServices managementServices)
        {
            _underwritingServices = underwritingServices;
            _productServices = productServices;
            _managementServices = managementServices;
        }

        #region Requests


        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST
        ///     {
        ///         "requestId": "string",
        ///         "brokerId": "e9400d14-f18d-474b-922a-2104e184f0af",
        ///         "productName": "Motor Policy",
        ///         "typeOfCover": "Third Party",
        ///         "insuredName": "Fransisca Sims",
        ///         "occupation": "Trader",
        ///         "emailAddress": "Sims@gmail.com",
        ///         "vehicleMake": "Lexus",
        ///         "yearOfMake": "2023",
        ///         "insuranceStartDate": "2023-03-08T13:09:36.156Z",
        ///         "vehicleValue": 10000000,
        ///         "startDate": "2023-03-08T13:09:36.156Z",
        ///         "insuredValue": 9000000,
        ///         "modeOfPayment": "Cheque",
        ///         "policyHolder": "Amarachi Ojela",
        ///         "mobile": "09038073651",
        ///         "address": "21 Commercial Avenue, Ikoyi",
        ///         "typeOfUsage": "Private",
        ///         "registrationNumber": "GLD901RT",
        ///         "premiumRate": 0,
        ///         "coverPeriod": 2,
        ///         "transactionDate": "2023-03-08T13:09:36.156Z",
        ///         "premium": 15000,
        ///         "idUploadUrl": "cbcca0-cacavacsacsa.png",
        ///         "utilityBillUploadUrl": "cbcca0-cacavacsacsa.png",
        ///         "vehicleLicenseUploadUrl": "cbcca0-cacavacsacsa.png",
        ///         "dateCreated": "2023-03-08T13:52:39.659Z"
        ///     }
        /// </remarks>
        /// <summary>
        ///     Accepts and process request data for motor and returns the request data when operation is successful.
        /// </summary>
        /// <response code="200">Returns Ok with quote data if submission was successful.</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="400">If any required data is missing</response>
        /// <response code="500">If something happened while submitting the request</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost, Route("submitrequestformotor")]
        public IActionResult SubmitRequestForMotor(Motor model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("All fields are required");
            }

            //Check if string is GUID Format
            if (!Utilities.IsGuid(model.BrokerId)) return BadRequest("User Id is in wrong format.");

            //Fetching User with supplied Id
            var result = _managementServices.GetUserById(model.BrokerId);

            if (result.HasError)
            {
                var resXX = Utilities.FormCustomResponse(result.ErrorMessage, "");

                return new JsonResult(resXX)
                {
                    StatusCode = 404,
                };
            }

            var producteResult = _productServices.GetProductByName(model.ProductName);
            if (producteResult.HasError) return BadRequest(producteResult.ErrorMessage);

            var packageResult = _productServices.GetPackageByName(model.TypeOfCover);
            if (packageResult.HasError) return BadRequest(packageResult.ErrorMessage);

            model.ProductId = producteResult.Payload.Id;
            model.PackageId = packageResult.Payload.Id;

            var request = RequestDto.FromMotor(model);

            var submitResult = _underwritingServices.SubmitRequestForMotor(request);

            if (submitResult.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened while submitting that request, please try again.", "");
                return new JsonResult(res)
                {
                    StatusCode = 500,
                };
            }

            var requestResult = _underwritingServices.GetRequestByRequestId(submitResult.Payload);

            var producteResultX = _productServices.GetProductById(requestResult.Payload.ProductId);

            requestResult.Payload.ProductName = producteResultX.Payload.ProductName;

            var resX = Utilities.FormCustomResponse("", requestResult.Payload);
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }

        #endregion
    }
}
