using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace EyeCT4RailsLogic.Helpers
{
    public class Hashing
    {
        /// <summary>
        /// Hashes a password with a given salt using SHA256.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashString(string password, string salt)
        {
            string ret;

            using (SHA256 hash = SHA256.Create())
            {
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                ret = Convert.ToBase64String(result);
            }

            return ret;
        }

        /// <summary>
        /// Gets a new salt.
        /// </summary>
        /// <returns>A new salty string.</returns>
        public static string GetNewSalt()
        {
            var rng = RNGCryptoServiceProvider.Create();
            var ret = new byte[64];
            rng.GetBytes(ret);
            return Convert.ToBase64String(ret);
        }
    }
}
