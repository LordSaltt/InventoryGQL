using System.Collections.Generic;

namespace GraphqlServer.Common
{
    public abstract class Payload
    {
        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }
        public IReadOnlyList<UserError>? Errors { get; }
        
    }
}