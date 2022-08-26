using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Permission : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Booking> UserSiteRoll { get; set; }
    }
}
