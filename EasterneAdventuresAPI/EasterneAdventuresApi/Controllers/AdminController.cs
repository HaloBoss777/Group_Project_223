using Microsoft.AspNetCore.Mvc;
using EasterneAdventuresApi.Core.Services;
using EasterneAdventuresApi.Core.DTOs;
using EasterneAdventuresApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using EasterneAdventuresApi.Web.Filters;
using EasterneAdventuresApi.Core.Models;
using System.Collections.Generic;
using System.Threading;

namespace EasterneAdventuresApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminService _adminService;

        public AdminController(IAdminService adminService) 
        {
            _adminService = adminService;
        }

        //Activities

        [HttpGet]
        [Route("~/api/Admin/ListActivities")]
        [AllowAnonymous]
        public List<ActivityDTO> GetAllActivities()
        {
            return _adminService.GetAllActivities();
        }

        [HttpPost]
        [Route("~/api/Admin/AddActivity")]
        [AllowAnonymous]
        public bool AddActivity(ActivityDTO itemToAdd)
        {
            return _adminService.AddActivity(itemToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateActivity")]
        [AllowAnonymous]
        public bool UpdateActivity(ActivityDTO itemToAdd)
        {
            return _adminService.UpdateActivity(itemToAdd);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteActivity")]
        [AllowAnonymous]
        public bool DeleteActivity(int activity_Id)
        {
            return _adminService.DeleteActivity(activity_Id);
        }

        //Employee

        [HttpGet]
        [Route("~/api/Admin/ListEmployee")]
        [AllowAnonymous]
        public List<EmployeeDTO> GetAllEmployee()
        {
            return _adminService.GetAllEmployee();
        }

        [HttpPost]
        [Route("~/api/Admin/AddEmployee")]
        [AllowAnonymous]
        public bool AddEmployee(EmployeeDTO empToAdd)
        {
            return _adminService.AddEmployee(empToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateEmployee")]
        [AllowAnonymous]
        public bool UpdateEmployee(EmployeeDTO empToAdd)
        {
            return _adminService.UpdateEmployee(empToAdd);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteEmployee")]
        [AllowAnonymous]
        public bool DeleteEmployee(int employee_Id)
        {
            return _adminService.DeleteEmployee(employee_Id);
        }
    }
}
