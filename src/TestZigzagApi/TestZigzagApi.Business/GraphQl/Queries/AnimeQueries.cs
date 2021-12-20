using HotChocolate;
using HotChocolate.Data;
using MongoDB.Driver;
using TestZigzagApi.Data.Entities;

namespace TestZigzagApi.Business.GraphQl.Queries
{
    public class AnimeQueries
    {
        [UseSorting]
        [UseFiltering]
        public IExecutable<AnimeEntity> GetAll([Service] IMongoCollection<AnimeEntity> collection)
        {
            return collection.AsExecutable();
        }
    }
}