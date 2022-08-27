using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Employee : BaseModel
    {
        public int Emp_Id { get; set; }
        public string FullName{ get; set; }
        public string PO_BOX { get; set; }
        public string Street { get; set; }
        public string Str_Num { get; set; }
        public string Area_Num{ get; set; }
        public string  CellNum { get; set; }
        public bool Instructor { get; set; }
        public bool Admin { get; set; }
        public string RSA_Id { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
