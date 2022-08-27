using EasterneAdventuresApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IAdminService
    {
        List<ActivityDTO> GetAllActivities();
        bool AddActivity(ActivityDTO activity);
        bool UpdateActivity(ActivityDTO activity);
        bool DeleteActivity(int activity_Id);

        List<EmployeeDTO> GetAllEmployee();

        bool AddEmployee(EmployeeDTO employee);
    }
}
