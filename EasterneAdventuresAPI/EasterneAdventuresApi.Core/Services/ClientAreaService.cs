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
    public class ClientAreaService : IClientArea
    {

		private readonly IEasterneAdventuresUnitOfWork _unitOfWork;


		public ClientAreaService(IEasterneAdventuresUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
		//Activity

		public List<ActivityDTO> GetAllActivities()
        {
			return _unitOfWork.Activity.Query().Select(x=>x.DisplayActivityDTO).ToList();
        }
		
		//Booking

		//Payment
	}
}
