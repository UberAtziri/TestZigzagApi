using System.Threading.Tasks;
using MongoDB.Driver;
using TestZigzagApi.Data.Entities;
using TestZigzagApi.Data.Repositories.Interfaces;

namespace TestZigzagApi.Data.Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly IMongoCollection<UserEntity> mongoCollection;
        public UserRepository(IMongoCollection<UserEntity> mongoCollection)
        {
            this.mongoCollection = mongoCollection;
        }

        public async Task CreateAsync(UserEntity userEntity)
        {
            await this.mongoCollection.InsertOneAsync(userEntity);
        }

        public async Task<UserEntity> IsExistAsync(string userName, string password)
        {
            var filters = Builders<UserEntity>.Filter.And(
                Builders<UserEntity>.Filter.Where(x => x.UserName == userName),
                Builders<UserEntity>.Filter.Where(x => x.Password == password));

            return await this.mongoCollection.Find(filters).FirstOrDefaultAsync();
        }
    }
}