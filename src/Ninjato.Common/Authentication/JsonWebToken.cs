namespace Ninjato.Common.Authentication
{
    /// <summary>
    /// Json web token.
    /// </summary>
    public class JsonWebToken
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>The expires.</value>
        public long Expires { get; set; }
    }
}
