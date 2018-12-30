using System;

namespace Ninjato.Services.Activity.Domain.Models
{
    /// <summary>
    /// Category.
    /// </summary>
    public class Category
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
        /// the following protected constructor is for serialization purposes
        /// </summary>
        protected Category()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Domain.Models.Category"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }
    }
}