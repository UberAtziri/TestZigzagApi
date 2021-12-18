using HotChocolate.Types;
using TestZigzagApi.Business.GraphQl.Queries;

namespace TestZigzagApi.Business.GraphQl.Types
{
    public class AnimeQueryType: ObjectType<AnimeQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimeQueries> descriptor)
        {
            descriptor
                .Field(f => f.GetAll(default))
                .Type<AnimeType>();
        }
    }
}