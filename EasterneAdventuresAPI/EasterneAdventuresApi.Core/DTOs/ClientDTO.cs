﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class ClientDTO
    {
        public int Client_Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CellNum { get; set; }
        public string RSA_ID { get; set; }
    }
}