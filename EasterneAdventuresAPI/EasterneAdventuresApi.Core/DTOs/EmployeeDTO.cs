using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Emp_ID { get; set; }
        public string Full_Name { get; set; }
        public string PO_Box { get; set; }
        public string Street { get; set; }
        public int Str_Num { get; set; }
        public string Area_Num { get; set; }
        public string CellNum { get; set; }
        public bool Instructor { get; set; }
        public bool Admin { get; set; }
        public string varchar { get; set; }
    }
}
