using System;

namespace Ninjato.Common.Commands
{
  public interface IAuthenticationCommand : ICommand
  {
    Guid UserId { get; set; }
  }
}