using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PasswordAuthentication
{
    public class HashingAndSalting
    {
        // This Method will create a Salt.
        public static byte[] CreateSalt()
        {
            // generate a 128-bit salt using a secure Pseudo Random Number Generator
            byte[] salt = new byte[128 / 8];
            using(var range = RandomNumberGenerator.Create())
            {
                range.GetBytes(salt);
            }
            return salt;
        }
        
        // this method takes the plaintext passowrd.
        // create a Hash with a Randomly Generated 128-bit Salt
        // return the salted Hash
        public static String CreateHashingWithSalt(string password)
        {
            byte[] salt = CreateSalt();
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));
            return hashed;
        }
        
        // this method takes the plaintext password .
        // create a salt, return the generated salt by out keyword
        // also return the generated Salted Hash
        public static String CreateHashingWithSalt(string password,out string saltValue)
        {
            byte[] salt = CreateSalt();
            saltValue = Convert.ToBase64String(salt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));
            return hashed;
        }
        
        // this method takes plaintext password and a Salt.
        // return a Salted Hash
        public static String CreateHashingWithSalt(string password, string salt)
        {

            byte[] saltingValue = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, saltingValue, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));

            return hashed;

        }
    }
}
