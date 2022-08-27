﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("~/api/Admin/DeleteActivity")]
        [AllowAnonymous]
        public bool DeleteActivity(int activity_Id)
        {
            return _adminService.DeleteActivity(activity_Id);
        }

    }
}