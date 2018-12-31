namespace Ninjato.Common.Events
{
    /// <summary>
    /// Create user rejected.
    /// </summary>
    public class CreateUserRejected : IRejectedEvent
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; }

        /// <summary>
        /// Gets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string Reason { get; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; }

        /// <summary>
        /// This ctor is used for serilaization purposes only.
        /// </summary>
        protected CreateUserRejected()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Events.CreateUserRejected"/> class.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="code">Code.</param>
        /// <param name="reason">Reason.</param>
        public CreateUserRejected(string email, string code, string reason)
        {
            Email = email;
            Code = code;
            Reason = reason;
        }
    }
}