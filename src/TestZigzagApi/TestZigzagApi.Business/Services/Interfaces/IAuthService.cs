using System.Threading.Tasks;

namespace TestZigzagApi.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string userName, string password);

        Task RegisterAsync(string userName, string password);
    }
}