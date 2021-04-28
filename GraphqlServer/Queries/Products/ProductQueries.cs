using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.DataLoader;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;

namespace GraphqlServer.Queries.Products
{
    [ExtendObjectType(Name = "Query")]
    public class ProductQueries
    {
        [UseApplicationDbContext]
        public Task<List<Product>> GetProducts([ScopedService] ApplicationDbContext context) =>
            context.Products.ToListAsync();

        public Task<Product> GetProductAsync([ID(nameof(Product))] int id,
            ProductByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);
    }
}