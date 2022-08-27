using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Activity : BaseModel
    {
        public int Activity_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price_PP { get; set; }

        public virtual List<ActivityEquipment> ActivityEquipments { get; set; }
        public virtual List<Booking> Bookings { get; set; }


        public ActivityDTO  DisplayActivityDTO => new ActivityDTO
        {
            Activity_Id = Activity_Id,
            Description = Description,
            Price_PP = Price_PP,
            Name = Name,
        };

    }
}
