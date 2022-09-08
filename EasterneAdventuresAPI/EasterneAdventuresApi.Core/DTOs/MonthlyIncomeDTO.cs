using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class MonthlyIncomeDTO
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
    }


}
