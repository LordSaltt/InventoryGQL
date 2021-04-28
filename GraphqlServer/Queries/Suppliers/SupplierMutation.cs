using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Subscriptions;

namespace GraphqlServer.Queries.Suppliers
{
    [ExtendObjectType(Name = "Mutation")]
    public class SupplierMutation
    {
        [UseApplicationDbContext]
        public async Task<AddSupplierPaylod> AddSupplierAsync(
            AddSupplierInput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender)
        {
            var record = new Supplier
            {
                Name = input.name,
                Address = input.address,
                Phone = input.phone,
                Contact = input.contact,
                Email = input.email,
                Comments = input.comments
            };

            await context.Suppliers.AddAsync(record);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(
                nameof(SuppliersSubscription.OnSupplierCreatedAsync),
                record.Id
            );

            return new AddSupplierPaylod(record);

        }
        
    }
}