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
        private readonly IAuthInfo _authInfo;

        public ClientAreaService(IEasterneAdventuresUnitOfWork unitOfWork, IAuthInfo authInfo)
		{
			_unitOfWork = unitOfWork;
            _authInfo = authInfo;
        }
		
		//Activity

		public List<ActivityDTO> GetAllActivities()
        {
			return _unitOfWork.Activity.Query().Select(x=>x.DisplayActivityDTO).ToList();
        }
		
		//Booking

		public bool CreateBooking(ClientBookingDTO New_Booking)
        {
            var create_Booking = new Booking()
            {
                Client_Id = _authInfo.UserId,
                Payment_Id = New_Booking.Payment_Id,
                Attendees = New_Booking.Atendees,
                Date_Booked = New_Booking.DateBooked,
                Activity_Id = New_Booking.Activity_Id,
                Emp_Id = _unitOfWork.Employee.Query().First().Emp_Id,
            };

            _unitOfWork.Booking.Add(create_Booking);
            _unitOfWork.Save();
            return true;
        }

		//Payment
	}
}
