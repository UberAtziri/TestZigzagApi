using System.Threading.Tasks;

namespace TestZigzagApi.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string userName, string password);

        Task Register(string userName, string password);
    }
}