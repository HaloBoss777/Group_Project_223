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
        public string Full_Name{ get; set; }
        public string PO_BOX { get; set; }
        public string Street { get; set; }
        public int Str_Num { get; set; }
        public string Area_Num{ get; set; }
        public string  CellNum { get; set; }
        public bool Instructor { get; set; }
        public bool Admin { get; set; }
        public string RSA_Id { get; set; }

        public virtual List<Booking> Bookings { get; set; }

        public EmployeeDTO DisplayEmployeeDTO => new EmployeeDTO
        {
            Emp_ID = Emp_Id,
            Full_Name = Full_Name,
            PO_Box = PO_BOX,
            Street = Street,
            Str_Num = Str_Num,
            Area_Num = Area_Num,
            CellNum = CellNum,
            Instructor = Instructor,
            Admin = Admin,
            RSA_Id = RSA_Id,

        };
    }
}
