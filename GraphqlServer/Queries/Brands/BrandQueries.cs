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

namespace GraphqlServer.Queries.Brands
{
    [ExtendObjectType(Name = "Query")]
    public class BrandQueries
    {
        [UseApplicationDbContext]
        public Task<List<Brand>> GetBrands([ScopedService] ApplicationDbContext context) =>
            context.Brands.ToListAsync();
        
        public Task<Brand> GetBrandAsync(
            [ID(nameof(Product))] int id,
            BrandByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);
    }
}