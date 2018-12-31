using System;
namespace Ninjato.Common.Events
{
    /// <summary>
    /// Create activity rejected.
    /// </summary>
    public class CreateActivityRejected
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; }

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
        protected CreateActivityRejected()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Events.CreateActivityRejected"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="code">Code.</param>
        /// <param name="reason">Reason.</param>
        public CreateActivityRejected(Guid id, string code, string reason)
        {
            Id = id;
            Code = code;
            Reason = reason;
        }
    }
}
