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
        UserAuthDTO signIn(UserAuthDTO user);
        List<Employee> listUsers();
        List<Site> ListSite();
        List<Permission> ListPermission();
        List<UserSiteRollDTO> ListUserSiteRoll();
    }
}
