using HotChocolate.Types;
using TestZigzag.Core.Common;

namespace TestZigzagApi.Business.GraphQl.Types
{
    public class AnimeType : ObjectType<AnimeDomain>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimeDomain> descriptor)
        {
            descriptor
                .Field(x => x.Description)
                .Type<StringType>();

            descriptor
                .Field(x => x.Id)
                .Type<StringType>();
            
            descriptor
                .Field(x => x.Name)
                .Type<StringType>();
            
            descriptor
                .Field(x => x.ReleaseDate)
                .Type<DateType>();
            
            descriptor
                .Field(x => x.Rating)
                .Type<FloatType>();
            
            descriptor
                .Field(x => x.CategoryName)
                .Type<StringType>();
            
            descriptor
                .Field(x => x.NumberOfEpisodes)
                .Type<IntType>();
        }
    }
}