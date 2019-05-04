using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer.AuthenticationService
{
    public interface IActiveClients
    {
        IReadOnlyDictionary<string,UserOnlineModel> OnlineUsers { get; }
        bool ChangeStatus(string address ,UserStatus status);
    }
}
