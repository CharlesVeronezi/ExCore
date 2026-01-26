using System.Security.Cryptography;
using System.Text;

namespace SagiCore.Auth.Application.Services
{
    public static class LegacyHashService
    {
        public static string ComputeMD5(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
