using System.Collections.Generic;
using System.Threading.Tasks;
using GraphqlServer.Models;
using HotChocolate.Types;

namespace GraphqlServer.Queries.Login
{
    [ExtendObjectType(Name = "Query")]
    public class LoginQueries
    {
        public Task<List<User>> GetUsers()
        {
            var Users = new List<User>
            {
                new User{
                    Id = 1,
                    UserName = "NBommidi",
                    Email = "naveen@gmail.com",
                    Password="1234",
                    Phone="8888899999"
                },
                new User{
                    Id = 2,
                    UserName = "HKumar",
                    Email = "hemanth@gmail.com",
                    Password = "abcd",
                    Phone = "2222299999"
                }
            };

            return Task.FromResult(Users);
        }
    }
}