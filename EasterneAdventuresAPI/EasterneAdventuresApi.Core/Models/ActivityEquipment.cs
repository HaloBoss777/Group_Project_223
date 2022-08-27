using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class ActivityEquipment : BaseModel
    {
        public int ActivityEquipment_Id { get; set; }
        public int Activity_Id { get; set; }
        public int Equipment_Id { get; set; }

    }
}
