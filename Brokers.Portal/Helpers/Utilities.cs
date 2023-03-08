using Brokers.Portal.Api.Models;
using Brokers.Portal.Modules.Management.Models;
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
                score += 2;

            return score;
        }

        public static CustomResponse FormCustomResponse(object? error, object? result)
        {
            if (error == "")
            {
                error = new object { };
            }
            if (result == "")
            {
                result = new object { };
            }

            CustomResponse res = new()
            {
                Error = error,
                Data = result,
            };


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
                CompanyId = user.CompanyId,
            };

            return userData;
        }

        public static bool IsEmailValid(string email)
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

        public static Boolean IsBase64String(string value)
        {
            if (value == null || value.Length == 0 || value.Length % 4 != 0
                || value.Contains(' ') || value.Contains('\t') || value.Contains('\r') || value.Contains('\n'))
                return false;
            var index = value.Length - 1;
            if (value[index] == '=')
                index--;
            if (value[index] == '=')
                index--;
            for (var i = 0; i <= index; i++)
                if (IsInvalid(value[i]))
                    return false;
            return true;
        }

        public static Boolean IsCompanyIdValid(string companyId)
        {
            string firstThree = companyId.Substring(0, companyId.IndexOf("-") + 1);
            var remCharacters = companyId.Substring(companyId.IndexOf("-") + 1);
            if (firstThree != "BP-") return false;
            if (remCharacters.Length > 5 || remCharacters.Length < 5 ) return false; 

            return true;

        }

        private static Boolean IsInvalid(char value)
        {
            var intValue = (Int32)value;
            if (intValue >= 48 && intValue <= 57)
                return false;
            if (intValue >= 65 && intValue <= 90)
                return false;
            if (intValue >= 97 && intValue <= 122)
                return false;
            return intValue != 43 && intValue != 47;
        }

        public static bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }
    }
}
