using EasterneAdventuresApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IAdminService
    {
        List<ActivityDTO> GetAllActivities();
    }
}
