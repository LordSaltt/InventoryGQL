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
    public class SupplierType : ObjectType<Supplier>
    {
        protected override void Configure(IObjectTypeDescriptor<Supplier> descriptor)
         {
             descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<SupplierByIdDataLoader>()
                    .LoadAsync(id, ctx.RequestAborted));            
         }
        
        private class SupplierResolvers
        {
            public async Task<IEnumerable<SupplierProduct>> GetSupplierProductsAsync(
                Supplier supplier,
                [ScopedService] ApplicationDbContext dbContext,
                SupplierProductByIdDataLoader supplierProductById,
                CancellationToken cancellationToken
            )
            {
                int[] ids = await dbContext.SupplierProducts
                    .Where(q => q.SupplierId == supplier.Id)
                    .Select(a => a.Id)
                    .ToArrayAsync();

                 return await supplierProductById.LoadAsync(ids, cancellationToken);
            }

        }
    }
}