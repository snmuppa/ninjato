using System;
using System.Security.Cryptography;

namespace Ninjato.Services.Identity.Domain.Services
{
    /// <summary>
    /// Encrypter.
    /// </summary>
    public class Encrypter : IEncrypter
    {
        private static readonly int SaltSize = 40;

        private static readonly int DerivedBytesIterationCount = 1000;

        /// <summary>
        /// Gets the salt.
        /// </summary>
        /// <returns>The salt.</returns>
        /// <param name="value">Value.</param>
        public string GetSalt(string value)
        {
            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <returns>The hash.</returns>
        /// <param name="value">Value.</param>
        /// <param name="salt">Salt.</param>
        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DerivedBytesIterationCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <returns>The bytes.</returns>
        /// <param name="value">Value.</param>
        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
