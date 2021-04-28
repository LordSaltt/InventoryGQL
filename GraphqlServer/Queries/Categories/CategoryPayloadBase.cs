using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Categories
{
    public class CategoryPayloadBase: Payload
    {
        protected CategoryPayloadBase(Category category)
        {
            Category = category;
        }

        protected CategoryPayloadBase (IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Category? Category { get; }
    }
}