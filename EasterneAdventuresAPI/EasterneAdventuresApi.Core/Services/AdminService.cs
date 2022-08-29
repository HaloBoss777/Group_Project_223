﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EasterneAdventuresApi.Core;
using EasterneAdventuresApi.Core.DTOs;
using EasterneAdventuresApi.Core.Interfaces;
using EASendMail;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace EasterneAdventuresApi.Core.Services
{
    public class AdminService : IAdminService
    {

        private readonly IEasterneAdventuresUnitOfWork _unitOfWork;


        public AdminService(IEasterneAdventuresUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Activities

        public List<ActivityDTO> GetAllActivities()
        {
            return _unitOfWork.Activity.Query().Select(x => x.DisplayActivityDTO).ToList();
        }

        public bool AddActivity(ActivityDTO activity)
        {
            var activityToAdd = new Activity()
            {
                Name = activity.Name,
                Description = activity.Description,
                Price_PP = activity.Price_PP,
            };
            _unitOfWork.Activity.Add(activityToAdd);
            _unitOfWork.Save();
            return true;
        }

        public bool UpdateActivity(ActivityDTO activity)
        {
            var activityToUpdate = _unitOfWork.Activity.Query(x => x.Activity_Id == activity.Activity_Id).SingleOrDefault();
            if (activityToUpdate == null)
            {
                return false;
            }

            activityToUpdate.Description = activity.Description;
            activityToUpdate.Name = activity.Name;
            activityToUpdate.Price_PP = activity.Price_PP;
            _unitOfWork.Save();

            return true;
        }

        public bool DeleteActivity(int activity_Id)
        {
            var activityToDelete = _unitOfWork.Activity.Query(x => x.Activity_Id == activity_Id).SingleOrDefault();
            if (activityToDelete == null)
            {
                return false;
            }

            _unitOfWork.Activity.Delete(activityToDelete);
            _unitOfWork.Save();
            return true;
        }

        //Employee

        public List<EmployeeDTO> GetAllEmployee()
        {
            return _unitOfWork.Employee.Query().Select(x => x.DisplayEmployeeDTO).ToList();
        }

        public bool AddEmployee(EmployeeDTO employee)
        {
            var employeeToAdd = new Employee()
            {
                Emp_Id = employee.Emp_ID,
                Full_Name = employee.Full_Name,
                PO_BOX = employee.PO_Box,
                Street = employee.Street,
                Str_Num = employee.Str_Num,
                Area_Num = employee.Area_Num,
                CellNum = employee.CellNum,
                Instructor = employee.Instructor,
                Admin = employee.Admin,
                RSA_Id = employee.RSA_Id,
            };

            _unitOfWork.Employee.Add(employeeToAdd);
            _unitOfWork.Save();
            return true;
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            var employeeToUpdate = _unitOfWork.Employee.Query(x => x.Emp_Id == employee.Emp_ID).SingleOrDefault();
            if(employeeToUpdate == null)
            {
                return false;
            }

            employeeToUpdate.Full_Name = employee.Full_Name;
            employeeToUpdate.PO_BOX = employee.PO_Box;
            employeeToUpdate.Street = employee.Street;
            employeeToUpdate.CellNum = employee.CellNum;
            employeeToUpdate.Str_Num = employee.Str_Num;
            employeeToUpdate.Area_Num = employee.Area_Num;
            employeeToUpdate.CellNum = employee.CellNum;
            employeeToUpdate.Instructor = employee.Instructor;
            employeeToUpdate.Admin = employee.Admin;
            employeeToUpdate.RSA_Id = employee.RSA_Id;
            _unitOfWork.Save();

            return true;
        }

        public bool DeleteEmployee(int employee_Id)
        {
            var EmployeeToDelete = _unitOfWork.Employee.Query(x => x.Emp_Id == employee_Id).SingleOrDefault();
            if (EmployeeToDelete == null)
            {
                return false;
            }

            _unitOfWork.Employee.Delete(EmployeeToDelete);
            _unitOfWork.Save();
            return true;
        }

        //Booking

        public List<BookingDTO> GetAllBookings()
        {
            return _unitOfWork.Booking.Query().Select(x => x.BookingDisplayDTO).ToList();
        }

        public bool AddBooking(BookingDTO booking)
        {
            var bookingToAdd = new Booking()
            {
                Activity_Id = booking.Activity_Id,
                Booking_Id = booking.Booking_Id,
                Emp_Id = booking.Emp_Id,
                Payment_Id = booking.Payment_Id,
                Client_Id = booking.Client_Id,
                Date_Booked = booking.Date_Booked,
            };

            _unitOfWork.Booking.Add(bookingToAdd);
            _unitOfWork.Save();
            return true;
        }

        public bool UpdateBooking(BookingDTO booking)
        {
            var bookingToUpdate = _unitOfWork.Booking.Query(x => x.Emp_Id == booking.Booking_Id).SingleOrDefault();
            if (bookingToUpdate == null)
            {
                return false;
            }

            bookingToUpdate.Activity_Id = booking.Activity_Id;
            bookingToUpdate.Booking_Id = booking.Booking_Id;
            bookingToUpdate.Emp_Id = booking.Emp_Id;
            bookingToUpdate.Payment_Id = booking.Payment_Id;
            bookingToUpdate.Client_Id = booking.Client_Id;
            bookingToUpdate.Date_Booked = booking.Date_Booked;
            _unitOfWork.Save();

            return true;
        }

        public bool DeleteBooking(int booking_Id)
        {
            var bookingToDelete = _unitOfWork.Booking.Query(x => x.Booking_Id == booking_Id).SingleOrDefault();
            if (bookingToDelete == null)
            {
                return false;
            }

            _unitOfWork.Booking.Delete(bookingToDelete);
            _unitOfWork.Save();
            return true;
        }
    }
}
