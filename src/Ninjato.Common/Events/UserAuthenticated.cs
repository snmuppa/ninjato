namespace Ninjato.Common.Events
{
    /// <summary>
    /// User authenticated.
    /// </summary>
    public class UserAuthenticated : IEvent
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; }

        protected UserAuthenticated()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Events.UserAuthenticated"/> class.
        /// </summary>
        /// <param name="email">Email.</param>
        public UserAuthenticated(string email)
        {
            Email = email;
        }
    }
}