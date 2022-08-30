using System;
using System.Collections.Generic;
using System.Text;
using EasterneAdventuresApi.Core.Models;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class UserAuthLoginDTO
    {
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
    }
}
