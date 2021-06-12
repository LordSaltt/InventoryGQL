using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;


namespace GraphqlServer.Queries.Suppliers
{
    public class AddSupplierProductPaylod: SupplierProductPayloadBase
    {
        public AddSupplierProductPaylod(SupplierProduct supplierProduct) : base(supplierProduct)
        {            
        }

        public AddSupplierProductPaylod(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}