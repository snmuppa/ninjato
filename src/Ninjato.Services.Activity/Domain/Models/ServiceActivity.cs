using System;

namespace Ninjato.Services.Activity.Domain.Models 
{
  public class ServiceActivity 
  {
    public Guid Id { get; protected set; }

    public string Name { get; protected set; }

    public Category Category { get; protected set; }

    ///
    // The User Id of the user that created the activity
    ///
    public Guid UserId { get; protected set; }

    public string Description { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

    protected ServiceActivity () 
    {

    }

    public ServiceActivity (Guid id, Category category, Guid userId,
      string name, string description, DateTime createdAt) {
      Id = id;
      Category = category;
      UserId = userId;
      Name = name.ToLowerInvariant ();
      Description = description;
      CreatedAt = createdAt;
    }
  }
}