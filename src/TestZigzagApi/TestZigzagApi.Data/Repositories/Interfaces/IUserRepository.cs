using System.Threading.Tasks;
using TestZigzagApi.Data.Entities;

namespace TestZigzagApi.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(UserEntity userEntity);

        Task<UserEntity> IsExistAsync(string userName, string password);
    }
}