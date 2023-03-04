using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Underwriting.Domain.Services;
using Brokers.Portal.Modules.Underwriting.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Brokers.Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnderwritingController : ControllerBase
    {
        private readonly IUnderwritingServices _underwritingServices;
        public UnderwritingController(IUnderwritingServices underwritingServices)
        {
            _underwritingServices = underwritingServices;
        }

        #region Quotes

        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("submitvehiclequote")]
        public IActionResult SubmitVehicleQuote(VehicleVM model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("All fields are required");
            }

            var result = _underwritingServices.SubmitVehicleQuote(model);

            if (result.HasError)
            {
                var res = Utilities.FormCustomResponse("Something happened, please try again.", "");
                return new JsonResult(res)
                {
                    StatusCode = 500,
                };
            }

            var resX = Utilities.FormCustomResponse("", "Quote Submitted Sucessfully.");
            return new JsonResult(resX)
            {
                StatusCode = 200,
            };
        }

        #endregion
    }
}
