using System.Collections.Generic;
using GraphqlServer.Common;
using GraphqlServer.Models;

namespace GraphqlServer.Queries.Register
{
    public class RegisterUserPayloadBase : Payload
    {
        protected RegisterUserPayloadBase (User user){
            User = user;
        }

        protected RegisterUserPayloadBase (IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public User? User { get; }
    }
}