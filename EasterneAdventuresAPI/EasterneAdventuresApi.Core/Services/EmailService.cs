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

namespace EasterneAdventuresApi.Core.Services
{
    public class EmailService : IEmailService
    {
        public string SendEmail(MessageDTO message) 
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new System.Net.Mail.MailAddress("esterneadventuresconfirmation@gmail.com");
                    mail.To.Add(message.SendEmail);
                    mail.Subject = message.Subject;
                    mail.Body = message.Body;
                    mail.IsBodyHtml = true;

                    using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("esterneadventuresconfirmation@gmail.com", "ftpvjcnotjuzjlmu");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception e) 
            {
                return e.Message;
            }

            return "Sent";
        }
    }
}
