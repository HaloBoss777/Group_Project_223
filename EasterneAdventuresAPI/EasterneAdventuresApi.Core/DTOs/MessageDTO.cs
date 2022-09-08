using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.DTOs
{
    public class MessageDTO
    {
        public string SendEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
