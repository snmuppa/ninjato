using System;

namespace Ninjato.Common.Events 
{
    /// <summary>
    /// Activity created.
    /// </summary>
    public class ActivityCreated : IAuthenticatedEvent 
    {
        public Guid UserId { get; }

        public Guid Id { get; }

        public string Category { get; }

        public string Name { get; }

        public string Description { get; }

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