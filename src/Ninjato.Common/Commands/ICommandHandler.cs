using System.Threading.Tasks;

namespace Ninjato.Common.Commands
{
  public interface ICommandHandler<in T> where T : ICommand
  {
      ///
      // This is an asynchronous method that handles the business logic for the input commands
      ///
      Task HandleAsync(T command);
  }
}