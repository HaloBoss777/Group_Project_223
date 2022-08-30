using System.Collections.Generic;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IAuthInfo
    {
        int UserId { get; set; }
        string DisplayName { get; set; }
        bool IsAdmin { get; set; }
        bool IsClient { get; set; }
    }
}