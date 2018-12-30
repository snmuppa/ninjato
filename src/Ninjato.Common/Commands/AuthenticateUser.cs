namespace Ninjato.Common.Commands 
{
    /// <summary>
    /// Authenticate user.
    /// </summary>
    public class AuthenticateUser : ICommand
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}