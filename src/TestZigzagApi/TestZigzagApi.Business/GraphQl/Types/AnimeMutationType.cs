using HotChocolate.Types;
using TestZigzagApi.Business.GraphQl.Mutations;

namespace TestZigzagApi.Business.GraphQl.Types
{
    public class AnimeMutationType : ObjectType<AnimeMutation>
    {
        protected override void Configure(
            IObjectTypeDescriptor<AnimeMutation> descriptor)
        {
            descriptor.Field(f => f.CreateAnime(default, default));
        }
    }
}