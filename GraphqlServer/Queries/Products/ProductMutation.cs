using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Subscriptions;

namespace GraphqlServer.Queries.Products
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProductMutation
    {
        [UseApplicationDbContext]
        public async Task<AddProductPayload> AddProductAsync(
            AddProductInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender)
        {
            var product = new Product
            {
                Name = input.name,
                Description = input.description,
                UOM = input.uom,
                Status = input.status,
                BrandId = input.brandId,
                CategoryId = input.categoryId
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(
                nameof(ProductsSubscription.OnProductCreatedAsync),
                product.Id
            );

            return new AddProductPayload(product);

        }
    }
}