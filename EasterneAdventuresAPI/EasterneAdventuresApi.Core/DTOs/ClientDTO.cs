using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class ClientDTO
    {
        public int Client_Id { get; set; }
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string CellNum { get; set; }
        public string RSA_ID { get; set; }
    }

    public class RegisterClient
    {
        public string Full_Name { get; set; }
        public string Email { get; set; }
        public string CellNum { get; set; }
        public string RSA_ID { get; set; }
        public string PasswordHash { get; set; }
    }
}
