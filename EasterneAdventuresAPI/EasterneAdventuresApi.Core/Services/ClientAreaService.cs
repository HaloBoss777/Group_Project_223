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
        private readonly ICryptographyHelper _cryptoService;

        public ClientAreaService(IEasterneAdventuresUnitOfWork unitOfWork, IAuthInfo authInfo, ICryptographyHelper cryptographyHelper)
		{
			_unitOfWork = unitOfWork;
            _authInfo = authInfo;
            _cryptoService = cryptographyHelper;
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


        public ShoppingCartPayDTO PayForCart(List<PayActivityDTO> cartItems)
        {

            var user = _unitOfWork.Client.Query(x=>x.Client_Id == _authInfo.UserId).Single();

            var firstName = user.Full_Name.Split()[0];

            decimal totalPrice = 0.00m;
            foreach (var item in cartItems)
            {
                var activityDetails = _unitOfWork.Activity.Query(x => x.Activity_Id == item.Activity_Id).Single();

                var createBooking = new Booking
                {
                    Attendees = item.Attending,
                    Activity_Id= item.Activity_Id,
                    Client_Id = _authInfo.UserId,
                    Date_Booked = DateTime.Now,
                    Payment_Id = null,
                    Emp_Id = 6
                };

                totalPrice += activityDetails.Price_PP * item.Attending;

                _unitOfWork.Booking.Add(createBooking);
                _unitOfWork.Save();
            }


            var genereatePayment = new Payment
            {
                Client_Id= _authInfo.UserId,
                TotalPrice = totalPrice,
                Paid = false,
                Booking_Id = (int)_unitOfWork.Booking.Query(x=>x.Client_Id ==_authInfo.UserId).Select(z=>z.Booking_Id).Last(),
            };

            _unitOfWork.Payment.Add(genereatePayment);
            _unitOfWork.Save();

            var cancelUrl = "https://lateralscaffoldingpre.azurewebsites.net/subscriptions?transactionId=";
            var returnUrl = "https://lateralscaffoldingpre.azurewebsites.net/subscriptions?transactionId=";
            var notifyUrl = "https://lateralscaffoldingpre.azurewebsites.net/subscriptions?transactionId=";

            var valuesDict = new Dictionary<string, string>
            {
                { "merchant_id", "10026285"},
                { "merchant_key", "rdgxv9mt28vbg"},

                { "return_url", returnUrl},
                { "cancel_url", cancelUrl},
                { "notify_url", notifyUrl},

                { "name_first", firstName},
                { "name_last", firstName},
                { "email_address", user.Email},

                { "m_payment_id", genereatePayment.Payment_Id.ToString()},
                { "amount", totalPrice.ToString().Replace(",",".")},
                { "item_name", "Buy Subscriptions"},
            };

            var hashedString = _cryptoService.GenerateHashedStringForPayFast(valuesDict);

            return new ShoppingCartPayDTO
            {
                Amount = totalPrice.ToString().Replace(",", "."),
                Hash = hashedString,
                TransactionId = genereatePayment.Payment_Id.ToString(),
                Email = user.Email,
                CancelUrl = cancelUrl,
                Name = firstName,
                NotifyUrl = notifyUrl,
                ReturnUrl = returnUrl,
                Surname = firstName,
                MerchantId = "10026285",
                MerchantKey = "rdgxv9mt28vbg",
                ServeURL = "https://sandbox.payfast.co.za/eng/process"
            };
        }

    }
}
