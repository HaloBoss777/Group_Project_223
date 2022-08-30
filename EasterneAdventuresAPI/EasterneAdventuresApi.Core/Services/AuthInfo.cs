using System.Collections.Generic;
using EasterneAdventuresApi.Core.Interfaces;

namespace EasterneAdventuresApi.Core.Services
{
	public class AuthInfo : IAuthInfo
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsClient { get; set; }
    }
}