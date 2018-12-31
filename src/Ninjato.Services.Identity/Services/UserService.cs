using System.Threading.Tasks;
using Ninjato.Common.Authentication;
using Ninjato.Common.Exceptions;
using Ninjato.Services.Identity.Domain.Models;
using Ninjato.Services.Identity.Domain.Repositories;
using Ninjato.Services.Identity.Domain.Services;

namespace Ninjato.Services.Identity.Services
{
    /// <summary>
    /// User service.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        private readonly IEncrypter _encrypter;

        private readonly IJwtHandler _jwtHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Identity.Services.UserService"/> class.
        /// </summary>
        /// <param name="repository">Repository.</param>
        /// <param name="encrypter">Encrypter.</param>
        /// <param name="jwtHandler">Jwt handler.</param>
        public UserService(IUserRepository repository, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _repository = repository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _repository.GetAsync(email);

            if(user == null)
            {
                throw new NinjatoException("invalid_credentials", $"Invalid credentials");
            }

            if(!user.ValidatePassword(password, _encrypter))
            {
                throw new NinjatoException("invalid_credentials", $"Invalid credentials");
            }

            return _jwtHandler.Create(user.Id);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="name">Name.</param>
        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _repository.GetAsync(email);

            if(user != null)
            {
                throw new NinjatoException("email_already_in_use", $"Email: '{email}' is already in use.");
            }

            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _repository.AddAsync(user);
        }
    }
}
