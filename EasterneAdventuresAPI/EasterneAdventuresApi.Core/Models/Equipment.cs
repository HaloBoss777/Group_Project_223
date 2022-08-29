using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.Models
{
    public class Equipment : BaseModel
    {
        public int Equipment_Id { get; set; }
        public string Name { get; set; }
        public bool Broken { get; set; }

        public virtual List<ActivityEquipment> ActivityEquipments { get; set; }

        public EquipmentDTO DisplayEquipmentDTO => new EquipmentDTO()
        {
            Equipment_Id = Equipment_Id,
            Name = Name,
            Broken = Broken,
        };
    }
}
