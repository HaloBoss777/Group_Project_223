using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Client : BaseModel
    {
        public int Client_Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CellNum { get; set; }
        public string RSA_ID { get; set; }
        public string PasswordHash { get; set; }


        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Payment> Payments { get; set; }

        public ClientDTO DisplayCLientDTO => new ClientDTO()
        {
            Client_Id = Client_Id,
            FullName = FullName,
            Email = Email,
            CellNum = CellNum,
            RSA_ID = RSA_ID,
        };
    }
}
