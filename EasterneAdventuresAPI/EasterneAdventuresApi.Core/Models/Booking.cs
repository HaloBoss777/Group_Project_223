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


    }
}
