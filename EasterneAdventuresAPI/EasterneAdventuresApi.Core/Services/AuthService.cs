using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EasterneAdventuresApi.Core;
using EasterneAdventuresApi.Core.DTOs;
using EasterneAdventuresApi.Core.Interfaces;
using EASendMail;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace EasterneAdventuresApi.Core.Services
{
    public class AuthService : IAuthService
    {

		private readonly IEasterneAdventuresUnitOfWork _unitOfWork;


		public AuthService(IEasterneAdventuresUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		private string GenerateJSONWebToken(UserAuthDTO user)
		{
			var jwtKey = "b0a63101-30e9-4d6a-bd22-a327c0cf9281";
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim("name",user.DisplayName),
				new Claim("isAdmin", user.IsAdmin.ToString()),
				new Claim("userId", user.Id.ToString()),
				new Claim("SiteId",user.SitePermissions.First(x=>x.SiteId != 0).SiteId.ToString()),
			};


			var token = new JwtSecurityToken("EasterneAdventuresApi.Core.Services.AuthenticationService",
			  "EasterneAdventuresApi.Web.Controllers.Authentication",
			  claims,
			  expires: DateTime.Now.AddDays(365),
			  signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
		
	}
}
