using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class ClientBookingDTO
    {
        public int Activity_Id { get; set; }
        public int Payment_Id { get; set; }
        public DateTime DateBooked { get; set; }
        public int Atendees { get; set; }
    }
}
