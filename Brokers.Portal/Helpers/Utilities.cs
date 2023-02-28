using Brokers.Portal.Api.Models;
using Brokers.Portal.Modules.Users.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;
using static Brokers.Portal.Api.Models.Responses;

namespace Brokers.Portal.Api.Helpers
{
    public class Utilities
    {
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 6
        }


        public static int CheckStrength(string password)
        {
            int score = 0;


            if (password.Length < 1)
                return 0;
            if (password.Length < 4)
                return 1;

            if (password.Length >= 6)
                score += 4;
            if (password.Length >= 10)
                score+= 2;

            return score;
        }

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

        public static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
