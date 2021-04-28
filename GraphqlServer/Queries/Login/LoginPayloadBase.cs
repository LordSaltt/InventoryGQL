using System.Collections.Generic;
using GraphqlServer.Common;

namespace GraphqlServer.Queries.Login
{
    public class LoginPayloadBase : Payload
    {
         protected LoginPayloadBase(string login)
        {
            Login = login;
        }

        protected LoginPayloadBase (IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public string? Login { get; }
        
    }
}