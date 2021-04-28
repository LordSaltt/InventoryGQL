using System.Reflection;
using GraphqlServer.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace GraphqlServer.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}