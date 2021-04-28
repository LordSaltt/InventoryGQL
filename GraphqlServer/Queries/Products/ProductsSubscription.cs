using System.Threading;
using System.Threading.Tasks;
using GraphqlServer.DataLoader;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphqlServer.Queries.Products
{
    [ExtendObjectType(Name = "Subscription")]
    public class ProductsSubscription
    {
        [Subscribe]
        [Topic]
        public Task<Product> OnProductCreatedAsync(
            [EventMessage] int productId,
            ProductByIdDataLoader productById,
            CancellationToken cancellationToken) =>
            productById.LoadAsync(productId, cancellationToken);
        
    }
}