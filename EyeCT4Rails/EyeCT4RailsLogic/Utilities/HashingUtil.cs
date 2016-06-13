using System;
using System.Security.Cryptography;
using System.Text;

namespace EyeCT4RailsLogic.Utilities
{
    public class HashingUtil
    {
        /// <summary>
        /// Hashes a password with a given salt using SHA256.
        /// </summary>
        /// <param name="password">Password that should be hashed.</param>
        /// <param name="salt">Salt that should be added to the hash.</param>
        /// <returns>The hashed string of the users password.</returns>
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
            var rng = RandomNumberGenerator.Create();
            var ret = new byte[64];
            rng.GetBytes(ret);
            return Convert.ToBase64String(ret);
        }
    }
}
