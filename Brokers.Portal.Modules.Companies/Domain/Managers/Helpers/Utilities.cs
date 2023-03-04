using System.Security.Cryptography;
using System.Text;

namespace Brokers.Portal.Modules.Users.Domain.Managers.Helpers
{
    public class Utilities
    {
        private const int CodeLength = 10;
        // since Random does not make any guarantees of thread-safety, use different Random instances per thread
        private static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random());

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedpassword);
        }

        public static bool CheckPasswordHash(string password, string storedPW)
        {
            string passwordHash = HashPassword(password);
            if (storedPW != passwordHash) return false;
            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public static string GenerateCompanyId()
        {
            char[] chars = "0123456789".ToCharArray();

            var sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                int num = _random.Value.Next(0, chars.Length);
                sb.Append(chars[num]);
            }
            return $"BR-{sb.ToString()}";
        }
    }
}
