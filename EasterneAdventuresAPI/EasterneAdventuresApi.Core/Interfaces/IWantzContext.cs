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
		IRepository<User> user { get; }
		IRepository<Booking> userSiteRoll { get; }
	}
}
