using System.Text;

namespace Brokers.Portal.Modules.Underwriting.Domain.Manager.Helpers
{
    public class Utilities
    {
        private const int CodeLength = 10;
        // since Random does not make any guarantees of thread-safety, use different Random instances per thread
        private static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random());
        public static string GenerateRequestId()
        {
            char[] chars = "0123456789".ToCharArray();

            var sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                int num = _random.Value.Next(0, chars.Length);
                sb.Append(chars[num]);
            }
            return $"#{sb.ToString()}";
        }
    }
}
