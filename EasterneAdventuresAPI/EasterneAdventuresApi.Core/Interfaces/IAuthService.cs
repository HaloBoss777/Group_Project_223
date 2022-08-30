using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasterneAdventuresApi.Core;
using EasterneAdventuresApi.Core.DTOs;
using EasterneAdventuresApi.Core.Models;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IAuthService
    {
        UserAuthDTO Login(UserAuthLoginDTO loginDetails);
    }
}
