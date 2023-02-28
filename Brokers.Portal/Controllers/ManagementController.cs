using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Management.Domain.Services;
using Brokers.Portal.Modules.Users.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.AspNetCore.Http;
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

        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet, Route("getuser")]
        public IActionResult GetUser(string email)
        {
            try
            {
                ApplicationUser? user = _managementServices.GetUser(email);

                User userX = new User()
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    isActive = user.isActive,
                    isEmailVerified = user.isEmailVerified,
                    isProfileUpdated = user.isProfileUpdated,
                };

                var res = Utilities.FormCustomResponse("00", "Success", "", userX);

                return new JsonResult(res)
                {
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        #endregion

    }
}
