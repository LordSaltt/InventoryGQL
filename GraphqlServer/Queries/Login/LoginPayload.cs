using System.Collections.Generic;
using GraphqlServer.Common;

namespace GraphqlServer.Queries.Login
{
    public class LoginPayload : LoginPayloadBase
    {
        public LoginPayload(string login) : base(login)
        {
        }

        public LoginPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}