using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Categories
{
    public class AddCategoryPayload : CategoryPayloadBase
    {
        public AddCategoryPayload(Category category) : base(category)
        {
        }

        public AddCategoryPayload(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}