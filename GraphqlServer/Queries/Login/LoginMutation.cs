using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphqlServer.Models;
using GraphqlServer.Shared;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GraphqlServer.Queries.Login
{

    [ExtendObjectType(Name = "Mutation")]
    public class LoginMutation
    {
        public async Task<LoginPayload> LoginAsync(            
            LoginInput input,
            [Service] IOptions<TokenSettings> tokenSettings)
        {

            var currentUser = Users.Where(u => u.Email.ToLower() == input.Email &&
            u.Password == input.Password).FirstOrDefault();
            var result = string.Empty;

            if (currentUser != null)
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.Value.Issuer,
                    audience: tokenSettings.Value.Audience,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
		        );
 
		        result = new JwtSecurityTokenHandler().WriteToken(jwtToken);
		
            }

            return await Task.FromResult(new LoginPayload(result));
        }

        private List<User> Users = new List<User>
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
    }
}