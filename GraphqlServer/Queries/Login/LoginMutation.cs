using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using GraphqlServer.Shared;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GraphqlServer.Queries.Login
{

    [ExtendObjectType(Name = "Mutation")]
    public class LoginMutation
    {
        [UseApplicationDbContext]
        public async Task<LoginPayload> LoginAsync(            
            LoginInput input,            
            [ScopedService] ApplicationDbContext context,
            [Service] IOptions<TokenSettings> tokenSettings)
        {            
            var currentUser = await context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == input.UserName.ToLower());
            

            var userIsVerify = VerifyPasswordHash(input.Password, currentUser.PasswordHash, currentUser.PasswordSaltt);
            var result = string.Empty;

            if(userIsVerify) {
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
            }
            return await Task.FromResult(new LoginPayload(result));
            //*/
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSaltt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSaltt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

      
    }
}