using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.DataLoader;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphqlServer.Types
{
    public class CategoryType : ObjectType<Category>
    {

        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {

            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<CategoryByIdDataLoader>()
                                             .LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(e => e.Products)
                .ResolveWith<ProductResolvers>(t => t.GetCategoryAsync(default!, default!, default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Name("Products");

            descriptor
                .Field(t => t.Name)
                .UseUpperCase();

        }

        private class ProductResolvers
        {
            public async Task<IEnumerable<Product>> GetCategoryAsync(
                Category category,
                [ScopedService] ApplicationDbContext dbContext,
                ProductByIdDataLoader productById,
                CancellationToken cancellationToken)
            {

                int[] prorducIds = await dbContext.Products.Where(q => q.CategoryId == category.Id)
                .Select(a => a.Id).ToArrayAsync();

                return await productById.LoadAsync(prorducIds, cancellationToken);
            }

        }

    }
}