using System;

namespace Ninjato.Common.Events 
{
  public class ActivityCreated : IAuthenticatedEvent {
    public Guid UserId { get; }

    public Guid Id { get; }

    public string Category { get; }

    public string Name { get; }

    public string Description { get; }

    public DateTime CreatedAt { get; }

    protected ActivityCreated () {

    }

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