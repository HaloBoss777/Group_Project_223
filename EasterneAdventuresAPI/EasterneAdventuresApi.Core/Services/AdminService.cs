using Microsoft.Extensions.Configuration;
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
    }
}
