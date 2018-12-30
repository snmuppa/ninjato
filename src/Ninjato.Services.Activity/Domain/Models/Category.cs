using System;

namespace Ninjato.Services.Activity.Domain.Models
{
  public class Category
  {
    public Guid Id { get; protected set; }

    public string Name { get; protected set; }

    // the following protected constructor is for serialization purposes
    protected Category()
    {

    }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name.ToLowerInvariant();
    }
  }
}