using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;


namespace GraphqlServer.Queries.Suppliers
{
    public class AddSupplierPayload: SupplierPayloadBase
    {
        public AddSupplierPayload(Supplier supplier) : base(supplier)
        {            
        }

        public AddSupplierPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}