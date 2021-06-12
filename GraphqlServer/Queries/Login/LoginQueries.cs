using System.Collections.Generic;
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphqlServer.Queries.Login
{
    [ExtendObjectType(Name = "Query")]
    public class LoginQueries
    {
        [UseApplicationDbContext]
        public async Task<List<User>> GetUsers([ScopedService] ApplicationDbContext context)
        {
            var users = await context.Users.ToListAsync();

            return users;
        }
    }
}