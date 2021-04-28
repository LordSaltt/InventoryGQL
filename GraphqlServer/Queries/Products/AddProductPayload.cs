using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Products
{
    public class AddProductPayload : ProductPayloadBase
    {
        public AddProductPayload(Product product) : base(product)
        {            
        }

        public AddProductPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}