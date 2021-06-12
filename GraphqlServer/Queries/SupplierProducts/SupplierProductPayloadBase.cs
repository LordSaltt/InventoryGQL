using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Suppliers
{
    public class SupplierProductPayloadBase : Payload
    {
        protected SupplierProductPayloadBase (SupplierProduct supplierProduct){
            SupplierProduct= supplierProduct;
        }

        protected SupplierProductPayloadBase (IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public SupplierProduct? SupplierProduct { get; }
        
    }
}