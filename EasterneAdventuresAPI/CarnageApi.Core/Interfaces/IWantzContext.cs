using System;
using System.Collections.Generic;
using System.Text;
using CarnageApi.Core.Models;

namespace CarnageApi.Core.Interfaces
{
	public class IWantzContext
	{
		IRepository<Permission> permission { get; }
		IRepository<Site> site { get; }
		IRepository<User> user { get; }
		IRepository<UserSiteRoll> userSiteRoll { get; }
	}
}
