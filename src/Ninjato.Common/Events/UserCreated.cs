namespace Ninjato.Common.Events
{
    /// <summary>
    /// User created.
    /// </summary>
    public class UserCreated : IEvent
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        // No event should pass along the password, only the service responsible for creating the user must have the access to the password

        /// <summary>
        /// This protected constructor is purely for serialization purposes 
        /// </summary>
        protected UserCreated()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Events.UserCreated"/> class.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="name">Name.</param>
        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}