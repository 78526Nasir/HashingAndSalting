using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace FrontCode.Libraries
{
    public class HashingAndSalting
    {

        /// <summary>
        /// Create a unique 128 bit salt;
        /// Generating salt by using a secure algorithm
        /// "Pseudo Random Number Generator"
        /// </summary>
        /// <returns>return salt</returns>
        public static byte[] CreateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var range = RandomNumberGenerator.Create())
            {
                range.GetBytes(salt);
            }

            return salt;
        }

        /// <summary>
        /// Generate Hash from a given plain text
        /// </summary>
        /// <param name="password"></param>
        /// <returns>return a 256 bytes of hash</returns>
        private static string GenerateHash(string password)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] dataBytes = Encoding.UTF8.GetBytes(password);
            byte[] resultBytes = sha256.ComputeHash(dataBytes);

            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// Create Hash with Salt
        /// Out parameter will out the salt generated by this method
        /// this salt is used further for authentication purpose
        /// </summary>
        /// <param name="password"></param>
        /// <param name="saltValue"></param>
        /// <returns>retrun saltedhash</returns>
        public static string CreateSaltedHash(string password, out string saltValue)
        {
            byte[] salt = CreateSalt(); // create a random salt
            saltValue = Convert.ToBase64String(salt); // convert the salt from byte to string and set it for out parameter
            string hash = GenerateHash(password); // generate hash for plain text password

            string generatedSaltedHash = GenerateHash(hash + saltValue); // generate hash with salt value

            return generatedSaltedHash;
        }

        /// <summary>
        /// Overloaded Method 
        /// It will use during user authentication
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string CreateSaltedHash(string password, string salt)
        {
            string hash = GenerateHash(password);
            string hashWithSalt = GenerateHash(hash + salt);

            return hashWithSalt;
        }
    }
}
