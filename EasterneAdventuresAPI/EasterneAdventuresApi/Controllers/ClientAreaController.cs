using Microsoft.AspNetCore.Mvc;
using EasterneAdventuresApi.Core.Services;
using EasterneAdventuresApi.Core.DTOs;
using EasterneAdventuresApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using EasterneAdventuresApi.Web.Filters;
using EasterneAdventuresApi.Core.Models;
using System.Collections.Generic;
using System.Threading;

namespace EasterneAdventuresApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAreaController : ControllerBase
    {
        public readonly IClientArea _clientArea;


        public ClientAreaController(IClientArea authService) 
        {
            _clientArea = authService;
        }

        [HttpGet]
        [Route("~/api/Client/ListActivities")]
        [AllowAnonymous]
        public List<ActivityDTO> GetAllActivities()
        {
            return  _clientArea.GetAllActivities();
        }

        [HttpPost]
        [Route("~/api/Client/Register")]
        [AllowAnonymous]
        public UserAuthDTO Register(RegisterClient clientDetails)
        {
            return _clientArea.Register(clientDetails);
        }

        [HttpPost]
        [Route("~/api/Client/CreateBooking")]
        [AuthorizationFilter]
        public bool CreateBooking(ClientBookingDTO New_Booking)
        {
            return _clientArea.CreateBooking(New_Booking);
        }

        [HttpPost]
        [Route("~/api/Client/PayForCart")]
        [AuthorizationFilter]
        public ShoppingCartPayDTO PayWithPayFast([FromBody] List<PayActivityDTO> cartItems)
        {
            return _clientArea.PayForCart(cartItems);
        }

        [HttpPost]
        [Route("~/api/PaymentComplete")]
        [PayFastDomainValidationAtribute]
        [AllowAnonymous]
        public void RecieveNotificationFromPayFast([FromHeader] PayFastNotifyDTO data)
        {
            _clientArea.HandlePayfastNotification(data);
        }
    }
}
