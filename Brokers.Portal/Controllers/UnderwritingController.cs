using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Underwriting.Domain.Services;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using Microsoft.AspNetCore.Mvc;
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
        public UnderwritingController(IUnderwritingServices underwritingServices)
        {
            _underwritingServices = underwritingServices;
        }

        #region Requests


        /// <remarks>
        /// Sample Response:
        /// 
        ///     {
        ///           "error": {},
        ///           "data": : {
        ///              "message": "Request submitted successfullly."
        ///           }
        ///     }
        /// </remarks>
        /// <summary>
        ///     Accepts request data for motor.
        /// </summary>
        /// <response code="200">Returns Ok if submission was successful.</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="400">If any required data is missing</response>
        /// <response code="500">If something happened while submitting the request</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost, Route("submitrequestformotor")]
        public IActionResult SubmitRequestForMotor(MotorVM model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("All fields are required");
            }

            var result = _underwritingServices.SubmitRequestForMotor(model);

            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened while submitting that request, please try again.", "");
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

        #endregion
    }
}
