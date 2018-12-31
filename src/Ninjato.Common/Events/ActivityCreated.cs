using System;

namespace Ninjato.Common.Events 
{
    /// <summary>
    /// Activity created.
    /// </summary>
    public class ActivityCreated : IAuthenticatedEvent 
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; }

        /// <summary>
        /// Gets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; }

        protected ActivityCreated () 
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Events.ActivityCreated"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="category">Category.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="createdAt">Created at.</param>
        public ActivityCreated(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}