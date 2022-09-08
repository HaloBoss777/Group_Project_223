using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class PaymentDTO
    {
        public int Payment_Id { get; set; }
        public int Booking_Id { get; set; }
        public int Client_Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? Paid { get; set; }
    }
}
