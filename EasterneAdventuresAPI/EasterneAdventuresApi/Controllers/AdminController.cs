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
using EasterneAdventuresApi.Core.Globals;

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
        [AuthorizationFilter(Permission.Admin)]
        public List<ActivityDTO> GetAllActivities()
        {
            return _adminService.GetAllActivities();
        }

        [HttpPost]
        [Route("~/api/Admin/AddActivity")]
        [AuthorizationFilter(Permission.Admin)]
        public bool AddActivity(ActivityDTO itemToAdd)
        {
            return _adminService.AddActivity(itemToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateActivity")]
        [AuthorizationFilter(Permission.Admin)]
        public bool UpdateActivity(ActivityDTO itemToUpdate)
        {
            return _adminService.UpdateActivity(itemToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteActivity")]
        [AuthorizationFilter(Permission.Admin)]
        public bool DeleteActivity(int activity_Id)
        {
            return _adminService.DeleteActivity(activity_Id);
        }

        //Employee

        [HttpGet]
        [Route("~/api/Admin/ListEmployee")]
        [AuthorizationFilter(Permission.Admin)]
        public List<EmployeeDTO> GetAllEmployee()
        {
            return _adminService.GetAllEmployee();
        }

        [HttpPost]
        [Route("~/api/Admin/AddEmployee")]
        [AuthorizationFilter(Permission.Admin)]
        public bool AddEmployee(EmployeeDTO empToAdd)
        {
            return _adminService.AddEmployee(empToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateEmployee")]
        [AuthorizationFilter(Permission.Admin)]
        public bool UpdateEmployee(EmployeeDTO empToUpdate)
        {
            return _adminService.UpdateEmployee(empToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteEmployee")]
        [AuthorizationFilter(Permission.Admin)]
        public bool DeleteEmployee(int employee_Id)
        {
            return _adminService.DeleteEmployee(employee_Id);
        }

        //Bookings

        [HttpGet]
        [Route("~/api/Admin/ListBookings")]
        [AuthorizationFilter(Permission.Admin)]
        public List<BookingDTO> GetAllBookings()
        {
            return _adminService.GetAllBookings();
        }

        [HttpPost]
        [Route("~/api/Admin/AddBooking")]
        [AuthorizationFilter(Permission.Admin)]
        public bool AddBooking(BookingDTO BookingToAdd)
        {
            return _adminService.AddBooking(BookingToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateBooking")]
        [AuthorizationFilter(Permission.Admin)]
        public bool UpdateBooking(BookingDTO BookingToUpdate)
        {
            return _adminService.UpdateBooking(BookingToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteBooking")]
        [AuthorizationFilter(Permission.Admin)]
        public bool DeleteBooking(int Booking_Id)
        {
            return _adminService.DeleteBooking(Booking_Id);
        }

        //Equipment

        [HttpGet]
        [Route("~/api/Admin/ListEquipment")]
        [AuthorizationFilter(Permission.Admin)]
        public List<EquipmentDTO> GetAllEquipment()
        {
            return _adminService.GetAllEquipment();
        }

        [HttpPost]
        [Route("~/api/Admin/AddEquipmnet")]
        [AuthorizationFilter(Permission.Admin)]
        public bool AddEquipment(EquipmentDTO EquipmentToAdd)
        {
            return _adminService.AddEquipment(EquipmentToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateEquipment")]
        [AuthorizationFilter(Permission.Admin)]
        public bool UpdateEquipment(EquipmentDTO EquipmentToUpdate)
        {
            return _adminService.UpdateEquipment(EquipmentToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteEquipment")]
        [AuthorizationFilter(Permission.Admin)]
        public bool DeleteEquipment(int Equipment_Id)
        {
            return _adminService.DeleteEquipment(Equipment_Id);
        }

        [HttpGet]
        [Route("~/api/Admin/ListActivityEquipment")]
        [AuthorizationFilter(Permission.Admin)]
        public List<EquipmentDTO> ListActivityEquipment(int activity_Id)
        {
            return _adminService.ListActivityEquipment(activity_Id);
        }
    }
}
