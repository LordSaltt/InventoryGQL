using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Brands
{
    public class BrandPayloadBase : Payload
    {
        protected BrandPayloadBase(Brand brand)
        {
            Brand = brand;
        }

        protected BrandPayloadBase (IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Brand? Brand { get; }
    }
}