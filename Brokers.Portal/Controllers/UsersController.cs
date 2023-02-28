using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Modules.Management.Domain.Services;
using Brokers.Portal.Modules.Users.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static Brokers.Portal.Api.Models.Responses;

namespace Brokers.Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;
        private readonly IManagementServices _managementServices;
        public UsersController(IConfiguration configuration, IUserServices userServices, IManagementServices managementServices)
        {
            _configuration = configuration;
            _userServices = userServices;
            _managementServices = managementServices;
        }


        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost, Route("authenticate")]
        public IActionResult Authenticate(UserDTO request)
        {
            try
            {
                var user = _managementServices.GetUser(request.Email);

                //Checking Email
                if (user?.Email != request.Email)
                {
                    var res = Utilities.FormCustomResponse("00", "Success", "User not found.", "");

                    return new JsonResult(res)
                    {
                        StatusCode = 200,
                    };
                }

                //Checking Password
                if (!_userServices.CheckPasswordHash(request.Password, user.PasswordHash))
                {
                    var resXX = Utilities.FormCustomResponse("00", "Success", "Wrong password.", "");

                    return new JsonResult(resXX)
                    {
                        StatusCode = 200,
                    };
                }

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                 _configuration.GetSection("AppSettings:Token").Value));

                //Creating Token
                string? token = _userServices.CreateToken(user, secretKey);

                var userData = Utilities.ConvertApplicationUserToUser(user);

                //var userRoles = _managementServices.GetUserRoles(user.UserId);

                var rolesAndPermissions = _managementServices.GetProcessFormPermission(new List<int> { 1, 2 });

                Profile profile = new Profile()
                {
                    UserData = userData,
                    ApplicationRoles = rolesAndPermissions,
                };

                LoginResp resX = new LoginResp()
                {
                    StatusCode = "00",
                    StatusDescription = "Success",
                    Message = "User Authenticated",
                    Token = token,
                    Profile = profile,
                };

                return new JsonResult(resX)
                {
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost, Route("register")]
        public IActionResult Register(UserDTO request)
        {
            try
            {
                bool isEmailValid = Utilities.IsValid(request.Email);
                if (request.Email.Length < 1) return BadRequest("Email field is reqyired");
                if (!isEmailValid || request.Email.Length < 1) return BadRequest("Email format is incorrect");


                var passwordScore = Utilities.CheckStrength(request.Password);
                if (passwordScore < 1) return BadRequest("Password field is required");
                if (passwordScore < 4) return BadRequest("Password is weak, try a longer password");
          
                var user = _managementServices.GetUser(request.Email);
                if (user != null) return BadRequest("User with that email address already exist.");
   

                //Adding user account to to database if email is not already in the recorrds
                string? message = _userServices.RegisterUser(request);

                if (message == null)
                {
                    var resX = Utilities.FormCustomResponse("00", "Success", "User Creation Failed.", "");

                    return new JsonResult(resX)
                    {
                        StatusCode = 200,
                    };
                }

                var userX = _managementServices.GetUser(request.Email);

                string mappingResponse = _managementServices.MapUserIdToRoles(userX.UserId, 2);

                var res = Utilities.FormCustomResponse("00", "Success", "User Created Successfully.", "");

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



    }
}
