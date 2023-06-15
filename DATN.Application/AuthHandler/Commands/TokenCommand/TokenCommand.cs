
using DATN.Application.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DATN.Infastructure.Repositories.AccountRepository;
using DATN.Infastructure.Repositories.ManagementRepository;

namespace DATN.Application.AuthHandler.Commands.TokenCommand
{
    public class TokenCommandResponse
    {
        public string AccessToken { get; set; } = default!;
       
        public int? ParkingCode { get; set; }
        public int Role { get; set; } = default!;

        

    }
    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenCommandResponse>
    {
        private readonly IConfiguration _config;
        private readonly IAccountRepository _accountRepo;
        private readonly IManagementRepository _management;

        public TokenCommandHandler(IConfiguration config, IAccountRepository accountRepo, IManagementRepository managent)
        {
            _config = config;
            _accountRepo = accountRepo;
            _management = managent;
        }

        public async Task<TokenCommandResponse> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            // Verificamos credenciales con Identity
            var account = await _accountRepo.CheckAuth(request.Username, request.Password);
            
            if (account is null)
            {
                throw new Exception();
            }
        


            //var roles = await _userManager.GetRolesAsync(user);

            //// Generamos un token según los claims
            var claims = new List<Claim>{
                new Claim(BClaimType.Name, account.Username),
            };

            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                //claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            if (account.Role == 1)
            {
                var management = await _management.CheckManagement(request.Username);
                TokenCommandResponse response = new TokenCommandResponse();
                response.ParkingCode = management.ParkingCode;
                response.Role = account.Role;
                response.AccessToken = jwt;
                return response;
            }

            return new TokenCommandResponse
            {
                AccessToken = jwt,

                Role = account.Role,

                ParkingCode = 0
            };
        }
    }
}
