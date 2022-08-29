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
        public bool UpdateActivity(ActivityDTO itemToUpdate)
        {
            return _adminService.UpdateActivity(itemToUpdate);
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
        public bool UpdateEmployee(EmployeeDTO empToUpdate)
        {
            return _adminService.UpdateEmployee(empToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteEmployee")]
        [AllowAnonymous]
        public bool DeleteEmployee(int employee_Id)
        {
            return _adminService.DeleteEmployee(employee_Id);
        }

        //Bookings

        [HttpGet]
        [Route("~/api/Admin/ListBookings")]
        [AllowAnonymous]
        public List<BookingDTO> GetAllBookings()
        {
            return _adminService.GetAllBookings();
        }

        [HttpPost]
        [Route("~/api/Admin/AddBooking")]
        [AllowAnonymous]
        public bool AddBooking(BookingDTO BookingToAdd)
        {
            return _adminService.AddBooking(BookingToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateBooking")]
        [AllowAnonymous]
        public bool UpdateBooking(BookingDTO BookingToUpdate)
        {
            return _adminService.UpdateBooking(BookingToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteBooking")]
        [AllowAnonymous]
        public bool DeleteBooking(int Booking_Id)
        {
            return _adminService.DeleteBooking(Booking_Id);
        }

        //Equipment

        [HttpGet]
        [Route("~/api/Admin/ListEquipment")]
        [AllowAnonymous]
        public List<EquipmentDTO> GetAllEquipment()
        {
            return _adminService.GetAllEquipment();
        }

        [HttpPost]
        [Route("~/api/Admin/AddEquipmnet")]
        [AllowAnonymous]
        public bool AddEquipment(EquipmentDTO EquipmentToAdd)
        {
            return _adminService.addEquipment(EquipmentToAdd);
        }

        [HttpPost]
        [Route("~/api/Admin/UpdateEquipment")]
        [AllowAnonymous]
        public bool UpdateEquipment(BookingDTO EquipmentToUpdate)
        {
            return _adminService.UpdateBooking(EquipmentToUpdate);
        }

        [HttpGet]
        [Route("~/api/Admin/DeleteEquipment")]
        [AllowAnonymous]
        public bool DeleteEquipment(int Equipment_Id)
        {
            return _adminService.deleteEquipment(Equipment_Id);
        }
    }
}
