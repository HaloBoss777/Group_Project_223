using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class ActivityDTO
    {
        public int Activity_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price_PP { get; set; }
        public DateTime? Date { get; set; }
        public int? Attending { get; set; }
    }

    public class PayActivityDTO
    {
        public int Activity_Id { get; set; }
        public int Attending { get; set; }
        public DateTime? Date { get; set; }
    }

}
