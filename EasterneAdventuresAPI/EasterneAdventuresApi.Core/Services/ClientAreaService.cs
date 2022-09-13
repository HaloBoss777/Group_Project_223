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
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;

        public ClientAreaService(IEasterneAdventuresUnitOfWork unitOfWork, IAuthInfo authInfo, ICryptographyHelper cryptographyHelper, IEmailService emailService,IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authInfo = authInfo;
            _cryptoService = cryptographyHelper;
            _emailService = emailService;
            _authService = authService;
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

            var bookingList = new List<int>();

            decimal totalPrice = 0.00m;
            foreach (var item in cartItems)
            {
                var activityDetails = _unitOfWork.Activity.Query(x => x.Activity_Id == item.Activity_Id).Single();

                var createBooking = new Booking
                {
                    Attendees = item.Attending,
                    Activity_Id= item.Activity_Id,
                    Client_Id = _authInfo.UserId,
                    Date_Booked = (DateTime)item.Date,
                    Payment_Id = null,
                    Emp_Id = 6
                };

                totalPrice += activityDetails.Price_PP * item.Attending;

                _unitOfWork.Booking.Add(createBooking);
                _unitOfWork.Save();
                bookingList.Add(createBooking.Booking_Id);
            }



            var genereatePayment = new Payment
            {
                Client_Id= _authInfo.UserId,
                TotalPrice = totalPrice,
                Paid = null,
                Booking_Id = bookingList.Last(),
            };

            _unitOfWork.Payment.Add(genereatePayment);
            _unitOfWork.Save();

            var bookingsToUpdate = _unitOfWork.Booking.Query(x=> bookingList.Contains(x.Booking_Id)).ToList();

            foreach (var item in bookingsToUpdate)
            {
                item.Payment_Id = genereatePayment.Payment_Id;
            }

            _unitOfWork.Save();

            var cancelUrl = "https://easterstorageadventures.z6.web.core.windows.net/Cart?status=Canceled";
            var returnUrl = "https://easterstorageadventures.z6.web.core.windows.net/Cart?status=Success";
            var notifyUrl = "https://esterneadventuresapi.azurewebsites.net/api/PaymentComplete";
            
            var valuesDict = new Dictionary<string, string>
            {
                { "merchant_id", "10027224"},
                { "merchant_key", "e0xnk43xuw9ff"},

                { "return_url", returnUrl},
                { "cancel_url", cancelUrl},
                { "notify_url", notifyUrl},

                { "name_first", firstName},
                { "name_last", firstName},
                { "email_address", user.Email},

                { "m_payment_id", genereatePayment.Payment_Id.ToString()},
                { "amount", totalPrice.ToString().Replace(",",".")},
                { "item_name", "Test Product"},
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
                MerchantId = "10027224",
                MerchantKey = "e0xnk43xuw9ff",
                ServeURL = "https://sandbox.payfast.co.za/eng/process"
            };
        }

        public void HandlePayfastNotification(PayFastNotifyDTO data)
        {
            var paymentToUpdate = _unitOfWork.Payment.Query(x=>x.Payment_Id == Convert.ToInt32(data.m_payment_id)).Single();
            paymentToUpdate.Paid = DateTime.Now;
            _unitOfWork.Save();
            var userDetails = _unitOfWork.Client.Query(x=>x.Client_Id == paymentToUpdate.Client_Id).Single();

            var bookings = _unitOfWork.Booking.Query(x=>x.Payment_Id == Convert.ToInt32(data.m_payment_id)).ToList();

            var body = $"<h1>Thank you for Booking with us</h1><br>";
            body += $"<h2>Your adventure Awaits</h2> <br><br>";
            body += $"<h3>Booked</h3>";
            var activities = new List<Activity>();
            foreach (var item in bookings)
            {
                var name = _unitOfWork.Activity.Query(x=>x.Activity_Id == item.Activity_Id).Select(c=>c.Name).Single();
                body+= $"{name} <br>";
            }


            _emailService.SendEmail(new MessageDTO
            {
                SendEmail = userDetails.Email,
                Body = body,
                Subject = "Payment Complete EsterneAdventures"
            });

        }

        public UserAuthDTO Register(RegisterClient registerClient)
        {
            var existingClient = _unitOfWork.Client.Query(x=>x.Email == registerClient.Email).SingleOrDefault();

            if (existingClient != null)
            {
                throw new Exception("User exists");
            }


            var clientToAdd = new Client
            {
                Email= registerClient.Email,
                Full_Name = registerClient.Full_Name,
                PasswordHash = registerClient.PasswordHash,
                RSA_ID = registerClient.RSA_ID,
                CellNum = registerClient.CellNum,
            };

            _unitOfWork.Client.Add(clientToAdd);
            _unitOfWork.Save();


            return _authService.Login(new UserAuthLoginDTO
            {
                PasswordHash = registerClient.PasswordHash,
                UserName = registerClient.Email
            });
        }

    }
}
