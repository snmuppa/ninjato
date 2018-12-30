using System;

namespace Ninjato.Common.Commands
{
  public class CreateActivity : IAuthenticationCommand
  {
    public Guid UserId { get; set; }

    public Guid Id { get; set; }

    public string Category { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}