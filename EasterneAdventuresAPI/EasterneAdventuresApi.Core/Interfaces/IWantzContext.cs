using System;
using System.Collections.Generic;
using System.Text;
using EasterneAdventuresApi.Core.Models;

namespace EasterneAdventuresApi.Core.Interfaces
{
	public class IWantzContext
	{
		IRepository<Permission> permission { get; }
		IRepository<Site> site { get; }
		IRepository<Employee> user { get; }
		IRepository<UserSiteRoll> userSiteRoll { get; }
	}
}
