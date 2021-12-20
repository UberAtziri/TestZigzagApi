using System.Threading.Tasks;
using TestZigzagApi.Data.Entities;

namespace TestZigzagApi.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task Create(UserEntity userEntity);

        Task<UserEntity> IsExist(string userName, string password);
    }
}