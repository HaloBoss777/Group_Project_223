using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Booking : BaseModel
    {
        public int Booking_Id { get; set; }
        public int Client_Id { get; set; }
        public int Activity_Id { get; set; }
        public int Emp_Id { get; set; }
        public int? Payment_Id { get; set; }
        public DateTime Date_Booked { get; set; }
        public int Attendees { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
        public virtual Activity Activity { get; set; }

        public BookingDTO BookingDisplayDTO => new BookingDTO
        {
            Activity_Id = Activity_Id,
            Emp_Id = Emp_Id,
            Booking_Id = (int)Booking_Id,
            Client_Id = Client_Id,
            Payment_Id = Payment_Id,
            Date_Booked = Date_Booked,
        };
    }
}
