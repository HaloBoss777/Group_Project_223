using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class BookingDTO
    {
        public int Booking_Id { get; set; }
        public int Client_Id { get; set; }
        public int Activity_Id { get; set; }
        public int Emp_Id { get; set; }
        public int? Payment_Id { get; set; }
        public DateTime Date_Booked { get; set; }
        public int Attendees { get; set; }
    }
}
