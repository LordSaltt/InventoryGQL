using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Register
{
    public class RegisterUserPayload : RegisterUserPayloadBase
    {
        public RegisterUserPayload(User user) : base(user)
        {            
        }

        public RegisterUserPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
        
    }
}