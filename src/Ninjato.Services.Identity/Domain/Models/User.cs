using System;
using Ninjato.Common.Exceptions;
using Ninjato.Common.Utilities;
using Ninjato.Services.Identity.Domain.Services;
using Ninjato.Services.Identity.Services;

namespace Ninjato.Services.Identity.Domain.Models
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; protected set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the salt for the password.
        /// </summary>
        /// <value>The salt.</value>
        public string Salt { get; protected set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// The ctor used for serilaization purposes.
        /// </summary>
        protected User()
        { 
        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Identity.Domain.Models.User"/> class.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="name">Name.</param>
        public User(string email, string name)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new NinjatoException("empty_user_email", $"User email cannot be empty.");
            } 
            else if(!Validators.IsValidEmail(email)) 
            {
                throw new NinjatoException("invalid_user_email", $"User email is invalid");
            }

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new NinjatoException("empty_user_name", $"User name cannot be empty.");
            }

            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets the password.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <param name="encrypter">Encrypter.</param>
        public void SetPassword(string password, IEncrypter encrypter)
        { 
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new NinjatoException("empty_password", $"Password cannot be empty.");
            }

            Salt = encrypter.GetSalt(password);
            Password = encrypter.GetHash(password, Salt);
        }

        /// <summary>
        /// Validates if the re-entered password (for confirmation) is same as the first entered password.
        /// </summary>
        /// <returns><c>true</c>, if password was validated, <c>false</c> otherwise.</returns>
        /// <param name="password">Password.</param>
        /// <param name="encrypter">Encrypter.</param>
        public bool ValidatePassword(string password, IEncrypter encrypter) 
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}
