using System;
using System.Collections.Generic;
using System.Text;
using EasterneAdventuresApi.Core.Models;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class UserAuthDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ApiToken { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsInstructor { get; set; }
        public bool IsClient { get; set; }
    }
}
