using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace TestZigzagApi.Configuration.Authentication
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection serviceCollection, string key)
        {
            var bytesKey = Encoding.ASCII.GetBytes(key);
            serviceCollection.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(bytesKey),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return serviceCollection;
        }
    }
}