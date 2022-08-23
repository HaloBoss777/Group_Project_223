using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasterneAdventuresApi.Core;
using EasterneAdventuresApi.Core.DTOs;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IEmailService
    {
        string SendEmail(MessageDTO message);
    }
}
