using System;

namespace Ninjato.Common.Events
{
    /// <summary>
    /// Authenticated event.
    /// </summary>
    public interface IAuthenticatedEvent : IEvent
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        Guid UserId { get; }
    }
}