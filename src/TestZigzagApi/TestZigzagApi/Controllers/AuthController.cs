using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestZigzagApi.Business.Services.Interfaces;
using TestZigzagApi.Models;

namespace TestZigzagApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task Register([FromBody] LoginRegisterRequest request)
        {
            await this.authService.RegisterAsync(request.UserName, request.Password);
        }
        
        [HttpGet]
        [Route("token")]
        public async Task<AuthResponse> GetToken([FromQuery] LoginRegisterRequest request)
        {
            var token = await this.authService.LoginAsync(request.UserName, request.Password);

            return new AuthResponse(token);
        }
    }
}