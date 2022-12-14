using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasterneAdventuresApi.Core.DTOs;
using System.Linq;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string DisplayName{ get; set; }
        public string Email{ get; set; }
        public string PasswordHash{ get; set; }
        public bool IsActive{ get; set; }

    }
}
