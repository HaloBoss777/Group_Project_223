using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;
using EasterneAdventuresApi.Core.Models;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class SiteDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public bool IsActive { get; set; }


    }
}
