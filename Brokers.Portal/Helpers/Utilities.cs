using Brokers.Portal.Api.Models;
using Brokers.Portal.Modules.Users.Models;
using static Brokers.Portal.Api.Models.Responses;

namespace Brokers.Portal.Api.Helpers
{
    public class Utilities
    {
        public static CustomResponse FormCustomResponse(string statusCode, string statusDescription, string message, object result)
        {
            CustomResponse res = new()
            {
                StatusCode = statusCode,
                StatusDescription = statusDescription,
                Message = message
            };
            if (result == "")
            {
                result = null;
            }
            res.result?.Add(result);

            return res;
        }

        public static User ConvertApplicationUserToUser(ApplicationUser user)
        {

            User userData = new User()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                isActive = user.isActive,
                isEmailVerified = user.isEmailVerified,
                isProfileUpdated = user.isProfileUpdated,
                Email = user.Email,
                Mobile = user.Mobile,
                Username = user.Username,
            };

            return userData;
        }
    }
}
