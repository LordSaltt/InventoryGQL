using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;


namespace GraphqlServer.Queries.Suppliers
{
    public class AddSupplierPaylod: SupplierPayloadBase
    {
        public AddSupplierPaylod(Supplier supplier) : base(supplier)
        {            
        }

        public AddSupplierPaylod(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}