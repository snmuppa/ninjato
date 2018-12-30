using System;

namespace Ninjato.Services.Activity.Domain.Models 
{
    /// <summary>
    /// Service activity.
    /// </summary>
    public class ServiceActivity 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public Category Category { get; protected set; }

        /// <summary>
        /// Gets or sets the User Id of the user that created the activity
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; protected set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; protected set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// the following protected constructor is for serialization purposes
        /// </summary>
        protected ServiceActivity () 
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Domain.Models.ServiceActivity"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="category">Category.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="createdAt">Created at.</param>
        public ServiceActivity (Guid id, Category category, Guid userId,
        string name, string description, DateTime createdAt) 
        {
            Id = id;
            Category = category;
            UserId = userId;
            Name = name.ToLowerInvariant ();
            Description = description;
            CreatedAt = createdAt;
        }
    }
}