using Brokers.Portal.Modules.Users.Models;

namespace Brokers.Portal.Api.Models
{
    public class Responses
    {
        public class CustomResponse
        {

            public string StatusCode { get; set; } = string.Empty;
            public string StatusDescription { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
            public List<object>? result { get; set; }

            public CustomResponse()
            {
                result = new List<object>();
            }
        }

        public class Profile
        {
            public User? UserData { get; set; }
            public IList<Roles> ApplicationRoles { get; set; }

            public Profile()
            {

                ApplicationRoles = new List<Roles>();
            }
        }

        public class LoginResp
        {
            public string? StatusCode { get; set; }
            public string? StatusDescription { get; set; }
            public string? Message { get; set; }
            public string? Token { get; set; }
            public Profile Profile { get; set; }
        }
    }   
}
