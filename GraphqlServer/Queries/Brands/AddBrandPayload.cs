using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Brands
{
    public class AddBrandPayload : BrandPayloadBase
    {
        public AddBrandPayload(Brand brand) : base(brand)
        {            
        }

        public AddBrandPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
        
    }
}