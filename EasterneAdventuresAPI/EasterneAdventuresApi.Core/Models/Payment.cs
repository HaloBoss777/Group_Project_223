using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Payment : BaseModel
    {
        public int Payment_Id { get; set; }
        public int Booking_Id { get; set; }
        public int Client_Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }

        public virtual Client Client { get; set; }
        public virtual Booking Booking { get; set; }

        public PaymentDTO DisplayPaymentDTO => new PaymentDTO()
        {
            Payment_Id = Payment_Id,
            Booking_Id = Booking_Id,
            Client_Id = Client_Id,
            TotalPrice = TotalPrice,
            Paid = Paid,
        };

    }
}
