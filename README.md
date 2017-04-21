    This project is all about password hashing and salting. How to hash a password with a 
    Pseudo Random Number Generator(PRNG) salt.
    How to store the salted Hash into the database and how to use this hashed password to authenticate a user.

   # HashingAndSalting
   # Password Hasing
   # Key Derivation
   # pbkd2f Algorithm 
   
   # Microsoft.AspNetCore.Cryptography.KeyDerivation
   
   * The package currently offers a method KeyDerivation.Pbkdf2 which allows hashing a password using the PBKDF2 algorithm.
     This API is very similar to the .NET Framework's existing Rfc2898DeriveBytes type, but there are three important distinctions:
     The KeyDerivation.Pbkdf2 method supports consuming multiple PRFs (currently HMACSHA1, HMACSHA256, and HMACSHA512), whereas the Rfc2898DeriveBytes type only supports HMACSHA1.
   
  * The KeyDerivation.Pbkdf2 method detects the current operating system and attempts to choose the most optimized 
    implementation of the routine, providing much better performance in certain cases. (On Windows 8,
    it offers around 10x the throughput of Rfc2898DeriveBytes.)
    The KeyDerivation.Pbkdf2 method requires the caller to specify all parameters (salt, PRF, and iteration count). 
    The Rfc2898DeriveBytes type provides default values for these.
