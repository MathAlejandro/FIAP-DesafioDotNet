using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Helper
{
    internal static class SecurityHelper
    {

        private static string HashSHA256(string value)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(value);
            var hashedValue = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedValue);
        }


        private static bool MatchSHA256(string value, string hashedValue)
        {
            var newHash = HashSHA256(value);
            
            return hashedValue.Equals(newHash);
        }


        public static string Hash(string value)
            => BCrypt.Net.BCrypt.HashPassword(value);

        public static bool Match(string value, string storedHash)
            => BCrypt.Net.BCrypt.Verify(value, storedHash);
    }
}
