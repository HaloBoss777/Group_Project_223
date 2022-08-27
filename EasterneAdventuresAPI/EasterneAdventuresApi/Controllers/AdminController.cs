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

        [HttpGet]
        [Route("~/api/Client/ListActivities")]
        [AllowAnonymous]
        public List<ActivityDTO> GetAllActivities()
        {
            return _adminService.GetAllActivities();
        }


        //[HttpGet]
        //[Route("~/api/ListUsers")]
        //[AllowAnonymous]
        //public List<Employee> ListUsers()
        //{
        //    Thread.Sleep(5000);
        //    return _authService.listUsers();
        //}

        //[HttpGet]
        //[Route("~/api/Sites")]
        //[AuthorizationFilter]
        //public List<Site> ListSites()
        //{
        //    return _authService.ListSite();
        //}

        //[HttpGet]
        //[Route("~/api/Permissions")]
        //[AuthorizationFilter]
        //public List<Permission> ListPermission()
        //{
        //    return _authService.ListPermission();
        //}

        //[HttpGet]
        //[Route("~/api/UserSiteRoll")]
        //[AuthorizationFilter]
        //public List<UserSiteRollDTO> ListUserSiteRoll()
        //{
        //    return _authService.ListUserSiteRoll();
        //}
    }
}
