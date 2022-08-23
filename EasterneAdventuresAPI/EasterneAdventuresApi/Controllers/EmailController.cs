using Microsoft.AspNetCore.Mvc;
using EasterneAdventuresApi.Core.Services;
using EasterneAdventuresApi.Core.DTOs;
using EasterneAdventuresApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EasterneAdventuresApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) 
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("~/api/SendEmail")]
        [AllowAnonymous]
        public string sendEmail(MessageDTO message)
        {
            return _emailService.SendEmail(message);
            //return true;
        }


        [HttpGet]
        [Route("~/api/Test")]
        [AllowAnonymous]
        public bool ApiTest()
        {
            return true;
            //return true;
        }
    }
}
