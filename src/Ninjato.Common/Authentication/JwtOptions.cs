namespace Ninjato.Common.Authentication
{
    /// <summary>
    /// Jwt options.
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        /// <value>The secret key.</value>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the expiry minutes.
        /// </summary>
        /// <value>The expiry minutes.</value>
        public int ExpiryMinutes { get; set; }

        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>The issuer.</value>
        public string Issuer { get; set; }
    }
}
