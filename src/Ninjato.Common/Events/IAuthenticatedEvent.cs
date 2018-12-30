using System;

namespace Ninjato.Common.Events
{
  public interface IAuthenticatedEvent : IEvent
  {
      Guid UserId { get; }
  }
}