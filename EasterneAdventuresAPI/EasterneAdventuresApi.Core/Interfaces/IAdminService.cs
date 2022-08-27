using EasterneAdventuresApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IAdminService
    {
        //Activities

        List<ActivityDTO> GetAllActivities();
        bool AddActivity(ActivityDTO activity);
        bool UpdateActivity(ActivityDTO activity);
        bool DeleteActivity(int activity_Id);

        //Employee

        List<EmployeeDTO> GetAllEmployee();

        bool AddEmployee(EmployeeDTO employee);

        bool UpdateEmployee(EmployeeDTO employee);

        bool DeleteEmployee(int employee_Id);

    }
}
