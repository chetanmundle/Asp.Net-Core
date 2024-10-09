using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using App.Core.Models.Api;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class JwtService
    {

        private readonly IAppDbContext _dbcontext;
        private readonly IConfiguration _configuration;
        public JwtService(IAppDbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbcontext = dbContext;
        }

        public async Task<LoginResponseModel?> Authenticate(LoginRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return null;

            var userAccount = await _dbcontext.Set<Domain.Entities.UserAccount>()
                                    .FirstOrDefaultAsync(x => x.UserName == request.UserName &&
                                                              x.Password == request.Password);

            if (userAccount is null) return null;

            var issuer = _configuration["JwtConfig:Issuer"];
            var audience = _configuration["JwtConfig:Audience"];
            var key = _configuration["JwtConfig:Key"];
            var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

            var toeknDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", userAccount.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, request.UserName),
                    new Claim("Password", userAccount.Password),
                    new Claim("UserEmail", userAccount.UserName),
                    new Claim("Age", userAccount.UserAge.ToString()),


                }),
                Expires = tokenExpiryTimeStamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha512Signature),

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(toeknDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            var result = new LoginResponseModel
            {
                AccessToken = accessToken,
                UserName = request.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };

            return result;
        }
    }
}
