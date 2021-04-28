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

namespace GraphqlServer.Queries.Categories
{
    [ExtendObjectType(Name = "Query")]
    public class CategoryQueries
    {

        [UseApplicationDbContext]
        public Task<List<Category>> GetCategories([ScopedService] ApplicationDbContext context) =>
            context.Categories.ToListAsync();
        
        public Task<Category> GetCategoryAsync(
            [ID(nameof(Product))] int id,
            CategoryByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);
        
    }
}