using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphqlServer.Queries.Brands
{
    [ExtendObjectType(Name = "Mutation")]
    public class BrandMutation
    {
        [UseApplicationDbContext]
        public async Task<AddBrandPayload> AddBrandAsync(
            AddBrandInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var brand = new Brand {
                Name = input.name
            };

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            return new AddBrandPayload(brand);

        }
    }
}