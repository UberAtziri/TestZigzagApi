using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestZigzag.Core.Common;
using TestZigzag.Core.Exceptions;
using TestZigzagApi.Business.Services.Interfaces;
using TestZigzagApi.Data.Entities;
using TestZigzagApi.Data.Repositories.Interfaces;

namespace TestZigzagApi.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly AuthOptions authOptions;

        public AuthService(IUserRepository userRepository, IOptions<AuthOptions> authOptions)
        {
            this.userRepository = userRepository;
            this.authOptions = authOptions.Value;
        }

        public async Task<string> Login(string userName, string password)
        {
            var user = await this.userRepository.IsExistAsync(userName, password);
            if (user == null)
            {
                throw new AuthFailedException(userName);
            }
 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.authOptions.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }),
                Expires = DateTime.UtcNow.AddDays(this.authOptions.ExpiredDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
 
            return tokenHandler.WriteToken(token);
        }

        public async Task Register(string userName, string password)
        {
            var model = new UserEntity
            {
                UserName = userName,
                Password = password
            };

            await this.userRepository.CreateAsync(model);
        }
    }
}