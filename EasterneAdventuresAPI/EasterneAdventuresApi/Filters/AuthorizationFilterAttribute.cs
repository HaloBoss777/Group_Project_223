using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Web;
using EasterneAdventuresApi.Core.Interfaces;
using EasterneAdventuresApi.Web.Controllers;
using EasterneAdventuresApi.Core.DTOs;
using Newtonsoft.Json;
using Castle.Core.Internal;
using System.IdentityModel.Tokens.Jwt;
using EasterneAdventuresApi.Core.Globals;

namespace EasterneAdventuresApi.Web.Filters
{
	public class AuthorizationFilterAttribute : ActionFilterAttribute
	{
		private string _permission;

		public AuthorizationFilterAttribute(string permission)
		{
			_permission = permission;
		}

		public AuthorizationFilterAttribute()
		{

		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var userClaimskeys = context.HttpContext.Request.Headers;
			var token = userClaimskeys.First(x => x.Key.Contains("Authorization")).Value.ToString().Substring(7);
			var handler = new JwtSecurityTokenHandler();
			var jwt = handler.ReadJwtToken(token);
			var fullname = jwt.Claims.First(claim => claim.Type == "fullName").Value;
			var userId = Int32.Parse(jwt.Claims.First(claim => claim.Type == "userId").Value);
			var isAdmin =	Convert.ToBoolean(jwt.Claims.First(claim => claim.Type == "isAdmin").Value);
			var IsClient = Convert.ToBoolean(jwt.Claims.First(claim => claim.Type == "isClient").Value);

            if (_permission != null)
            {
				if (_permission.Equals(Permission.Admin) && !isAdmin)
				{
					throw new UnauthorizedAccessException();
				}
			}

            ((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).DisplayName = fullname;
			((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).UserId = userId;
			((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).IsAdmin = isAdmin;
			((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).IsClient = IsClient;
		}
	}
}
