namespace Ninjato.Common.Events
{
    /// <summary>
    /// Create user rejected.
    /// </summary>
    public class CreateUserRejected : IRejectedEvent
    {
        public string Email { get; }

        public string Reason { get; }

        public string Code { get; }

        protected CreateUserRejected()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Events.CreateUserRejected"/> class.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="reason">Reason.</param>
        /// <param name="code">Code.</param>
        public CreateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}