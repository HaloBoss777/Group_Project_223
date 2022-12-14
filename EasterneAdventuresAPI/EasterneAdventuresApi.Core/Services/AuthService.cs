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
using System.Configuration;

namespace EasterneAdventuresApi.Core.Services
{
    public class AuthService : IAuthService
    {

		private readonly IEasterneAdventuresUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration ;

		public AuthService(IEasterneAdventuresUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		private string GenerateJSONWebToken(UserAuthDTO user)
		{
			var jwtKey = "b0a63101-30e9-4d6a-bd22-a327c0cf9281";
			var credentials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

			var claims = new List<Claim>
			{
				new Claim("fullName",user.FullName),
				new Claim("isAdmin", user.IsAdmin.ToString()),
				new Claim("userId", user.Id.ToString()),
				new Claim("isClient", user.IsClient.ToString()),
			};

			var newclaims = claims.AsEnumerable<Claim>();

			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
			  _configuration["Jwt:Audience"],
			  newclaims,
			  expires: DateTime.Now.AddDays(365));

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public UserAuthDTO Login(UserAuthLoginDTO loginDetails)
        {
			var employee = _unitOfWork.Employee.Query(x=>x.RSA_Id == loginDetails.UserName && x.PasswordHash == loginDetails.PasswordHash).SingleOrDefault();
			var client = _unitOfWork.Client.Query(x => x.Email == loginDetails.UserName && x.PasswordHash == loginDetails.PasswordHash).SingleOrDefault();

            if (employee != null)
            {
				var employeeDetails = new UserAuthDTO
				{
					FullName = employee.Full_Name,
					Id = employee.Emp_Id,
					IsAdmin = employee.Admin,
					IsClient = false,
					IsInstructor = employee.Instructor
				};
				employeeDetails.ApiToken = GenerateJSONWebToken(employeeDetails);

				return employeeDetails;
			}
            if (client != null)
            {
				var clientDetails = new UserAuthDTO
				{
					FullName = client.Full_Name,
					Id = client.Client_Id,
					IsAdmin = false,
					IsClient = true,
					IsInstructor = false,
				};
				clientDetails.ApiToken = GenerateJSONWebToken(clientDetails);
				return clientDetails;
			}
			throw new UnauthorizedAccessException("Details Incorrect");
        }


	}
}
