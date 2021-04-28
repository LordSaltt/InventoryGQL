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

namespace GraphqlServer.Queries.Suppliers
{
    [ExtendObjectType(Name = "Query")]
    public class SupplierQueries
    {
        [UseApplicationDbContext]
        public Task<List<Supplier>> GetSuppliers([ScopedService] ApplicationDbContext context) =>
            context.Suppliers.ToListAsync();

        public Task<Supplier> GetSupplierAsync([ID(nameof(Supplier))] int id,
            SupplierByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);        
    }
}