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

    public class BookingDetailsDTO
    {
        public int Booking_Id { get; set; }
        public int Client_Id { get; set; }
        public string Client_Full_Name { get; set; }
        public string Client_RSA_Id { get; set; }
        public string Client_Cell { get; set; }
        public int Activity_Id { get; set; }
        public string Activity_Name { get; set; }
        public decimal Activity_PP { get; set; }
        public int? Payment_Id { get; set; }
        public decimal? Payment_Amount { get; set; }
        public string Date_Booked { get; set; }
        public int Attendees { get; set; }
    }
}
