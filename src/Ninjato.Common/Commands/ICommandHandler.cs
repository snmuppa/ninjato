using System.Threading.Tasks;

namespace Ninjato.Common.Commands
{
    /// <summary>
    /// Command handler.
    /// </summary>
    public interface ICommandHandler<in T> where T : ICommand
    {
        /// <summary>
        /// This is an asynchronous method that handles the business logic for the input commands
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="command">Command.</param>
        Task HandleAsync(T command);
    }
}