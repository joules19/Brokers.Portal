using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Management.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brokers.Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementServices _managementServices;
        public ManagementController(IManagementServices managementServices)
        {
            _managementServices = managementServices;
        }

        #region Users

        //[ApiExplorerSettings(IgnoreApi = false)]
        //[HttpGet, Route("getuser")]
        //public IActionResult GetUser(string email)
        //{

        //    var result = _managementServices.GetUser(email);

        //    if (result?.HasError != null)
        //    {
        //        var user = result.Payload;

        //        User userX = new User()
        //        {
        //            UserId = user.UserId,
        //            Username = user.Username,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            MiddleName = user.MiddleName,
        //            Email = user.Email,
        //            Mobile = user.Mobile,
        //            isActive = user.isActive,
        //            isEmailVerified = user.isEmailVerified,
        //            isProfileUpdated = user.isProfileUpdated,
        //        };

        //        var res = Utilities.FormCustomResponse("", userX);

        //        return new JsonResult(res)
        //        {
        //            StatusCode = 200,
        //        };
        //    }

        //    var resX = Utilities.FormCustomResponse("User not found.", "");

        //    return new JsonResult(resX)
        //    {
        //        StatusCode = 404,
        //    };


        //}
        #endregion

    }
}
