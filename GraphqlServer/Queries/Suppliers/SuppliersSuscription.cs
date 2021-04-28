using System.Threading;
using System.Threading.Tasks;
using GraphqlServer.DataLoader;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;


namespace GraphqlServer.Queries.Suppliers
{
    [ExtendObjectType(Name = "Subscription")]
    public class SuppliersSubscription
    {
        public Task<Supplier> OnSupplierCreatedAsync(
            [EventMessage] int supplierId,
            SupplierByIdDataLoader supplierById,
            CancellationToken cancellationToken) =>
            supplierById.LoadAsync(supplierId, cancellationToken);
        
    }
}