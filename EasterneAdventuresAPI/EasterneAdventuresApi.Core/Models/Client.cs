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

        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
}
