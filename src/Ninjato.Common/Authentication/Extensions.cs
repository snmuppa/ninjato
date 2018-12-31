using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Ninjato.Common.Authentication
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds the jwt.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new JwtOptions();
            var section = configuration.GetSection("Jwt");
            section.Bind(options);
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddAuthentication()
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidIssuer = options.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey))
                    };
                });
        }
    }
}
