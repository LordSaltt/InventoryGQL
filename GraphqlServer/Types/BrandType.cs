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
    public class BrandType : ObjectType<Brand>
    {

        protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
        {

            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<BrandByIdDataLoader>()
                                             .LoadAsync(id, ctx.RequestAborted));
            
            descriptor
                .Field(e=> e.Products)
                .ResolveWith<ProductResolvers> (t=> t.GetBrandAsync(default!,default!,default!,default!))
                .UseDbContext<ApplicationDbContext>()
                .Name("Products");

            descriptor
                .Field(t => t.Name)
                .UseUpperCase();

        }

        private class ProductResolvers
         {
             public async Task<IEnumerable<Product>> GetBrandAsync(
                 Brand brand, 
                 [ScopedService] ApplicationDbContext dbContext,
                 ProductByIdDataLoader productById,
                 CancellationToken cancellationToken)
             {

                 int[] prorducIds = await dbContext.Products
                    .Where(q => q.BrandId == brand.Id)
                    .Select(a => a.Id)
                    .ToArrayAsync();

                 return await productById.LoadAsync(prorducIds, cancellationToken);
             }

         }
        
    }
}