using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class ActivityEquipmentDTO
    {
        public int ActivityEquipment_Id { get; set; }
        public int Activity_Id { get; set; }
        public int Equipment_Id { get; set; }
    }
}
