using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Suppliers
{
    public class SupplierPayloadBase : Payload
    {
         protected SupplierPayloadBase (Supplier supplier){
            Supplier = supplier;
        }

        protected SupplierPayloadBase (IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Supplier? Supplier { get; }        
    }
}