using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate.Types;

namespace GraphqlServer.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        { 
            descriptor
                .Field(t => t.UserName)
                .UseUpperCase()
                .Authorize();

        }
    }
}