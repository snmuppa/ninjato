using System;

namespace Ninjato.Common.Commands
{
    /// <summary>
    /// Authentication command.
    /// </summary>
    public interface IAuthenticationCommand : ICommand
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        Guid UserId { get; set; }
    }
}