using System.Threading;
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.DataLoader;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace GraphqlServer.Types
{
    public class ProductType: ObjectType<Product>
    {
         protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
         {
             descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<ProductByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

             descriptor
                .Field(e=> e.Brand)
                .ResolveWith<ProductResolvers> (t=> t.GetBrandAsync(default!,default!,default!,default!))
                .UseDbContext<ApplicationDbContext>()
                .Name("Brand");

            descriptor
                .Field(e=> e.Category)
                .ResolveWith<ProductResolvers> (t=> t.GetCategoryAsync(default!,default!,default!,default!))
                .UseDbContext<ApplicationDbContext>()
                .Name("Category");
         }

         private class ProductResolvers
         {
             public async Task<Brand> GetBrandAsync(
                 Product product, 
                 [ScopedService] ApplicationDbContext dbContext,
                 BrandByIdDataLoader brandById,
                 CancellationToken cancellationToken)
             {

                 return await brandById.LoadAsync(product.BrandId, cancellationToken);
             }

              public async Task<Category> GetCategoryAsync(
                 Product product, 
                 [ScopedService] ApplicationDbContext dbContext,
                 CategoryByIdDataLoader categoryById,
                 CancellationToken cancellationToken)
             {

                 return await categoryById.LoadAsync(product.CategoryId, cancellationToken);
             }

         }
    }
}