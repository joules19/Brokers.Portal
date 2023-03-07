using Brokers.Portal.Api.Helpers;
using Brokers.Portal.Models;
using Brokers.Portal.Modules.Company.Domain.Services;
using Brokers.Portal.Modules.Management.Domain.Services;
using Brokers.Portal.Modules.Users.Domain.Services;
using Brokers.Portal.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Text;
using static Brokers.Portal.Api.Models.Responses;

namespace Brokers.Portal.Api.Controllers
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;
        private readonly IManagementServices _managementServices;
        private readonly ICompanyServices _companyServices;
        public UsersController(
            IConfiguration configuration,
            IUserServices userServices,
            IManagementServices managementServices,
            ICompanyServices companyServices
          )
        {
            _configuration = configuration;
            _userServices = userServices;
            _managementServices = managementServices;
            _companyServices = companyServices;
        }




        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST
        ///     {
        ///         "companyId": "BP-11111",
        ///         "loginCredential": "asW2rW5AZ21haWwuY29tOnVzbWFuMTIz"
        ///     }
        /// Sample Response:
        /// 
        ///     {
        ///          "error": {},
        ///          "data": {
        ///              "userId": "o94UUd14-f18d-474b-922a-2104e184f0af"
        ///           }
        ///     }
        /// </remarks>
        /// <summary>
        /// Authenticates user then returns the userId after successful authentication.
        /// </summary>
        /// <response code="200">User authentication success.</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="400">Bad request: if any of companyId or password is incorrect.</response>
        /// <response code="404">Not Found: if user with that email address does not exist.</response>
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthResp))]
        [HttpPost, Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthVm request)
        {
            //Check Company details with company Id
            var companyResult = _companyServices.GetCompanyByCompanyId(request.CompanyId);

            if (companyResult.HasError) return BadRequest("Company Id is invalid");

            if (!companyResult.Payload.IsActive) return BadRequest("Company is not active");

            //Decoding base64 logincredentials
            byte[] encodedStringToByte = Convert.FromBase64String(request.LoginCredential);
            string decodedString = Encoding.UTF8.GetString(encodedStringToByte);

            var email = decodedString.Substring(0, decodedString.IndexOf(":"));
            var password = decodedString.Substring(decodedString.IndexOf(":") + 1);

            var userResult = _managementServices.GetUser(email);
            if (userResult.HasError)
            {
                var res = Utilities.FormCustomResponse(userResult.ErrorMessage, "");
                return new JsonResult(res)
                {
                    StatusCode = 404,
                };
            }

            var user = userResult.Payload;

            if (user.CompanyId != request.CompanyId) return BadRequest("Supplied Company Id does not match Company Id in our records.");

            //Checking Password
            if (!_userServices.CheckPasswordHash(password, user.PasswordHash))
            {
                var resX = Utilities.FormCustomResponse("Wrong password.", "");

                return new JsonResult(resX)
                {
                    StatusCode = 404,
                };
            }

            var resXX = Utilities.FormCustomResponse("", new AuthResp { UserId = user.UserId });
            return new JsonResult(resXX)
            {
                StatusCode = 200,
            };
        }



        /// <summary>
        ///     Accepts a valid user Id then returns the corresponding user profile.
        /// </summary>
        /// <response code="200">Ok Response with User profile object</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="400">Bad request: if user Id is in wrong format.</response>
        /// <response code="404">Not Found: if user with that email address does not exist.</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Profile))]
        [HttpGet, Route("getprofile")]
        public IActionResult GetProfile(string userId)
        {
            //Check if string is GUID Format
            if (!Utilities.IsGuid(userId)) return BadRequest("User Id is in wrong format.");

            //Fetching User with supplied Id
            var result = _managementServices.GetUserById(userId);
            if (result.HasError)
            {
                var resX = Utilities.FormCustomResponse(result.ErrorMessage, "");

                return new JsonResult(resX)
                {
                    StatusCode = 404,
                };
            }
            var userData = Utilities.ConvertApplicationUserToUser(result.Payload);

            //Fetching roles and permissions as per user
            //var userRoles = _managementServices.GetUserRoles(user.UserId);
            var rolesAndPermissions = _managementServices.GetProcessFormPermission(new List<int> { 1, 2 });

            Profile profile = new Profile()
            {
                UserData = userData,
                ApplicationRoles = rolesAndPermissions,
            };

            var res = Utilities.FormCustomResponse("", profile);
            return new JsonResult(res)
            {
                StatusCode = 200,
            };
        }


        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST
        ///     {
        ///         "signupCredential": "asW2rW5AZ21haWwuY29tOnVzbWFuMTIz"
        ///     }
        /// Sample Response:
        /// 
        ///     {
        ///          "error": {},
        ///          "data": "User Registered Successfully."
        ///     }
        /// </remarks>
        /// <summary>
        ///     Registers a new user.
        /// </summary>
        /// <response code="201">If the user was created successfully</response>
        /// <response code="401">If the request is not authorized</response>
        /// <response code="400">Bad request: If Supplied Email or Password is in wrong format.
        /// Bad Request: If a user with the supplied email already exists.
        /// </response>
        /// <response code="500">If an unknown error occured while registering user.</response>
        [ApiExplorerSettings(IgnoreApi = false)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [HttpPost, Route("register")]
        public IActionResult Register(RegisterVm request)
        {
            byte[] encodedStringToByte = Convert.FromBase64String(request.SignupCredential);
            string decodedString = Encoding.UTF8.GetString(encodedStringToByte);

            var email = decodedString.Substring(0, decodedString.IndexOf(":"));
            var password = decodedString.Substring(decodedString.IndexOf(":") + 1);

            bool isEmailValid = Utilities.IsEmailValid(email);
            if (email.Length < 1) return BadRequest("Email field is reqired");
            if (!isEmailValid || email.Length < 1) return BadRequest("Email format is incorrect");

            var passwordScore = Utilities.CheckStrength(password);
            if (passwordScore < 1) return BadRequest("Password field is required");
            if (passwordScore < 4) return BadRequest("Password is weak, try a longer password");

            var user = _managementServices.GetUser(email);
            if (user.Payload != null) return BadRequest("User with that email address already exist.");

            //Adding user account to to database if email is not already in the records
            var idResult = _companyServices.GenerateCompanyId();
            UserDTO newUser = new UserDTO();
            if (idResult.Payload != null)
            {
                newUser.Email = email;
                newUser.Password = password;
                newUser.CompanyId = idResult.Payload.ToString();
            };

            var result = _userServices.RegisterUser(newUser);
            if (result.HasError)
            {
                var resX = Utilities.FormCustomResponse("User Creation Failed.", "");
                return new JsonResult(resX)
                {
                    StatusCode = 500,
                };
            }

            var userX = _managementServices.GetUser(email);

            if (userX.Payload != null) _managementServices.MapUserIdToRoles(userX.Payload.UserId, 2);
            
            var res = Utilities.FormCustomResponse("", result.Payload);
            return new JsonResult(res)
            {
                StatusCode = 201,
            };
        }
    }
}


//string accessTokenToJson = JsonConvert.SerializeObject(accessTokenObj);
//var getAccessTokenResponse = JsonConvert.DeserializeObject<AccessTokenViewModel>(accessTokenToJson);

//string toBeEconded = "usman@gmail.com" + ":" + "usman123";;
//string base64EncodedAuthorization = Convert.ToBase64String(Encoding.UTF8.GetBytes(toBeEconded));