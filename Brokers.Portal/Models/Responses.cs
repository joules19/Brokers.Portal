using Brokers.Portal.Modules.Users.Models;

namespace Brokers.Portal.Api.Models
{
    public class Responses
    {
        public class CustomResponse
        {

            public object Error { get; set; }
            public object Data { get; set; }

        }
        public class AuthResp
        {
            public string UserId { get; set; } = String.Empty;
        }
        public class ErrorResp
        {
            public string ErrorMesssage { get; set; } = String.Empty;
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
