using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Products
{
    public class ProductPayloadBase : Payload
    {
        protected ProductPayloadBase (Product product){
            Product = product;
        }

        protected ProductPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Product? Product { get; }
    
    }
}