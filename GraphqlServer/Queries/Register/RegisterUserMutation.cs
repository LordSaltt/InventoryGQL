using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Subscriptions;


namespace GraphqlServer.Queries.Register
{
    [ExtendObjectType(Name = "Mutation")]
    public class RegisterUserMutation
    {
        [UseApplicationDbContext]
        public async Task<RegisterUserPayload> RegisterUserAsync(
            RegisterUserIput input,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender) 
        {

            byte[] passwordHash, passwordSaltt;
            CreatePasswordHash(input.password, out passwordHash, out passwordSaltt);

            var user = new User
            {
                UserName = input.userName,
                Password = input.password,
                PasswordHash = passwordHash,
                PasswordSaltt = passwordSaltt
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new RegisterUserPayload(user);
        }

         private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSaltt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSaltt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
    }
}