using System;

namespace Ninjato.Common.Authentication
{
    /// <summary>
    /// JsonWebToken handler.
    /// </summary>
    public interface IJwtHandler
    {
        /// <summary>
        /// Create a JWT for a given userId.
        /// </summary>
        /// <returns>The created JWT.</returns>
        /// <param name="userId">User identifier.</param>
        JsonWebToken Create(Guid userId);
    }
}
